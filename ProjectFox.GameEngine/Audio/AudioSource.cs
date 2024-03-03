﻿using ProjectFox.CoreEngine.Collections;
using ProjectFox.CoreEngine.Math;
using ProjectFox.GameEngine.Visuals;

namespace ProjectFox.GameEngine.Audio;

public abstract class AudioSource : Object2D
{
    public AudioSource(NameID name) : base(name) { }

    public AudioChannel channel = null;

    public readonly ICollection<Object2D> listeners = new Array<Object2D>(0x4);

    public bool audible = true, repeat = false, exceedMaxVolume = false;

    public float volume = 1f, leftVolume = 1f, rightVolume = 1f, panning = 0f, maxVolumeDistance = 1f;

    protected abstract Sample[] GetDrawInfo();

    internal sealed override void _draw(VisualLayer layer = null)
    {
#if DEBUG
        base._draw();
#endif
        
        if (!audible || volume <= 0f || (leftVolume <= 0f && rightVolume <= 0)) return;

        if (channel == null)
        {
            Engine.SendError(ErrorCodes.NullAudioChannel, name);
            return;
        }

        if (!channel.audible || channel.volume <= 0 || (channel.leftVolume <= 0f && rightVolume <= 0f)) return;

        if (scene != channel.scene || (owner != null && owner.scene != channel.scene))
            Engine.SendError(ErrorCodes.AudioChannelNotInScene, name, channel.name.ToString(),
                $"AudioSource '{name}' drew to channel from a null/different scene");

        Sample[] waveShape = GetDrawInfo();
        
        if (waveShape == null)
        {
            Engine.SendError(ErrorCodes.NullWaveShape, name);
            return;
        }

        float v = volume;

        Array<Object2D> listeners = (Array<Object2D>)this.listeners;
        if (listeners.length > 0)//this makes it quieter if closer
        {
            Object2D closest = Closest(listeners.ToArray());//overload for awway<>?
            v *= closest.position.Distance(position) / maxVolumeDistance;
        }

        if (!exceedMaxVolume && v > 1f) v = 1f;//should l/r vol be clamped?

        bool leftPan = panning < 0, rightPan = panning > 0;
        float l = v * leftVolume, r = v * rightVolume, pan = leftPan ? -panning : panning, reversePan = 1 - pan;

        //Debug.Console.QueueMessage(Speakers.SamplesPerFrame * Engine.TimeOfLastFrame);

        for (int i = 0; i < waveShape.Length; i++)
        {
            int addedLength = waveShape.Length - channel.samples.length;
            if (addedLength > 0) channel.samples.AddLength(addedLength);

            Sample sample = waveShape[i], channelSample = channel.samples.elements[i];//does channel need a different index?
            float left = sample.left * l, right = sample.right * r;

            if (leftPan)
            {
                left += right * pan;
                right *= reversePan;
            }
            else if (rightPan)
            {
                right += left * pan;
                left *= reversePan;
            }

            if (!channel.monophonic)
            {
                left += channelSample.left;
                right += channelSample.right;
            }
            
            channel.samples.elements[i] = new(//could the double clamp be abbreviated?
                (short)(Math.Clamp(left, short.MinValue, short.MaxValue)),
                (short)(Math.Clamp(right, short.MinValue, short.MaxValue)));
        }

        if (!repeat) audible = false;
    }
}

public class SampleSource : AudioSource
{
    public SampleSource(NameID name) : base(name) { }

    public Sample[] waveShape = null;

    protected override Sample[] GetDrawInfo() => waveShape;
}

#if DEBUG
public class OSCSource : AudioSource
{
    public enum InterpolationMode
    {
        Up,
        Down,
        Both
    }

    public enum Note
    {
        CNatural,
        CSharp,
        DNatural,
        DSharp,
        ENatural,
        FNatural,
        FSharp,
        GNatural,
        GSharp,
        ANatural,
        ASharp,
        BNatural,

        DFlat = CSharp,
        EFlat = DSharp,
        GFlat = FSharp,
        AFlat = GSharp,
        BFlat = ASharp,
    }

    public OSCSource(NameID name, Sample[] waveShape/*, int octave?*/) : base(name) { }//input an A4 note 440hz?

    //Sample[][] single cycle waveforms, each Sample[] is an A note, octaves 0-9
    private readonly Sample[][] waveShapes = new Sample[10][];

    public InterpolationMode mode = InterpolationMode.Up;

    public bool repeat = true;//?

    public Note note = Note.ANatural;

    public int octave = 4;

    public float pitchOffest = 0f;

    //samplerate?

    //polyphony?

    protected override Sample[] GetDrawInfo() => Engine.SendError<Sample[]>(ErrorCodes.NotImplemented, name);

    //public void SetNote(int octave, Note note, float pitchOffest = 0f) { }//?

    //public void SetNote(float freq) { }//?
}
#endif