﻿using System;
using F = System.IO.File;
using D = System.Diagnostics.Debug;

using ProjectFox.CoreEngine.Math;
using M = ProjectFox.CoreEngine.Math.Math;

using ProjectFox.GameEngine;
using C = ProjectFox.GameEngine.Debug.Console;
using ProjectFox.GameEngine.Audio;
using ProjectFox.GameEngine.Visuals;
using ProjectFox.GameEngine.Input;

using static ProjectFox.TestBed.DebugNames;

namespace ProjectFox.TestBed;

public static partial class GameEngineTest
{
    private const string Path = "E:\\Other\\Mega Man ZX - Green Grass Gradation 2.wav";

    private static readonly Sample[] TestShape =
    {
        //Mono
        new(00000), new(00100), new(00200), new(00300), new(00400), new(00500), new(00600), new(00700), new(00800), new(00900),
        new(01000), new(01100), new(01200), new(01300), new(01400), new(01500), new(01600), new(01700), new(01800), new(01900),
        new(02000), new(02100), new(02200), new(02300), new(02400), new(02500), new(02600), new(02700), new(02800), new(02900),
        new(03000), new(03100), new(03200), new(03300), new(03400), new(03500), new(03600), new(03700), new(03800), new(03900),
        new(04000), new(04100), new(04200), new(04300), new(04400), new(04500), new(04600), new(04700), new(04800), new(04900),
        new(05000), new(05100), new(05200), new(05300), new(05400), new(05500), new(05600), new(05700), new(05800), new(05900),
        new(06000), new(06100), new(06200), new(06300), new(06400), new(06500), new(06600), new(06700), new(06800), new(06900),
        new(07000), new(07100), new(07200), new(07300), new(07400), new(07500), new(07600), new(07700), new(07800), new(07900),
        new(08000), new(08100), new(08200), new(08300), new(08400), new(08500), new(08600), new(08700), new(08800), new(08900),
        new(09000), new(09100), new(09200), new(09300), new(09400), new(09500), new(09600), new(09700), new(09800), new(09900),

        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),

        //Left
        new(00000, 0), new(00100, 0), new(00200, 0), new(00300, 0), new(00400, 0), new(00500, 0), new(00600, 0), new(00700, 0), new(00800, 0), new(00900, 0),
        new(01000, 0), new(01100, 0), new(01200, 0), new(01300, 0), new(01400, 0), new(01500, 0), new(01600, 0), new(01700, 0), new(01800, 0), new(01900, 0),
        new(02000, 0), new(02100, 0), new(02200, 0), new(02300, 0), new(02400, 0), new(02500, 0), new(02600, 0), new(02700, 0), new(02800, 0), new(02900, 0),
        new(03000, 0), new(03100, 0), new(03200, 0), new(03300, 0), new(03400, 0), new(03500, 0), new(03600, 0), new(03700, 0), new(03800, 0), new(03900, 0),
        new(04000, 0), new(04100, 0), new(04200, 0), new(04300, 0), new(04400, 0), new(04500, 0), new(04600, 0), new(04700, 0), new(04800, 0), new(04900, 0),
        new(05000, 0), new(05100, 0), new(05200, 0), new(05300, 0), new(05400, 0), new(05500, 0), new(05600, 0), new(05700, 0), new(05800, 0), new(05900, 0),
        new(06000, 0), new(06100, 0), new(06200, 0), new(06300, 0), new(06400, 0), new(06500, 0), new(06600, 0), new(06700, 0), new(06800, 0), new(06900, 0),
        new(07000, 0), new(07100, 0), new(07200, 0), new(07300, 0), new(07400, 0), new(07500, 0), new(07600, 0), new(07700, 0), new(07800, 0), new(07900, 0),
        new(08000, 0), new(08100, 0), new(08200, 0), new(08300, 0), new(08400, 0), new(08500, 0), new(08600, 0), new(08700, 0), new(08800, 0), new(08900, 0),
        new(09000, 0), new(09100, 0), new(09200, 0), new(09300, 0), new(09400, 0), new(09500, 0), new(09600, 0), new(09700, 0), new(09800, 0), new(09900, 0),

        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),

        //Right
        new(0, 00000), new(0, 00100), new(0, 00200), new(0, 00300), new(0, 00400), new(0, 00500), new(0, 00600), new(0, 00700), new(0, 00800), new(0, 00900),
        new(0, 01000), new(0, 01100), new(0, 01200), new(0, 01300), new(0, 01400), new(0, 01500), new(0, 01600), new(0, 01700), new(0, 01800), new(0, 01900),
        new(0, 02000), new(0, 02100), new(0, 02200), new(0, 02300), new(0, 02400), new(0, 02500), new(0, 02600), new(0, 02700), new(0, 02800), new(0, 02900),
        new(0, 03000), new(0, 03100), new(0, 03200), new(0, 03300), new(0, 03400), new(0, 03500), new(0, 03600), new(0, 03700), new(0, 03800), new(0, 03900),
        new(0, 04000), new(0, 04100), new(0, 04200), new(0, 04300), new(0, 04400), new(0, 04500), new(0, 04600), new(0, 04700), new(0, 04800), new(0, 04900),
        new(0, 05000), new(0, 05100), new(0, 05200), new(0, 05300), new(0, 05400), new(0, 05500), new(0, 05600), new(0, 05700), new(0, 05800), new(0, 05900),
        new(0, 06000), new(0, 06100), new(0, 06200), new(0, 06300), new(0, 06400), new(0, 06500), new(0, 06600), new(0, 06700), new(0, 06800), new(0, 06900),
        new(0, 07000), new(0, 07100), new(0, 07200), new(0, 07300), new(0, 07400), new(0, 07500), new(0, 07600), new(0, 07700), new(0, 07800), new(0, 07900),
        new(0, 08000), new(0, 08100), new(0, 08200), new(0, 08300), new(0, 08400), new(0, 08500), new(0, 08600), new(0, 08700), new(0, 08800), new(0, 08900),
        new(0, 09000), new(0, 09100), new(0, 09200), new(0, 09300), new(0, 09400), new(0, 09500), new(0, 09600), new(0, 09700), new(0, 09800), new(0, 09900),

        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
        new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000), new(00000),
    };

    private static readonly Sample[] TestShape2 =
    {
        new(00000), new(00100), new(00200), new(00300), new(00400), new(00500), new(00600), new(00700), new(00800), new(00900),
        new(01000), new(01100), new(01200), new(01300), new(01400), new(01500), new(01600), new(01700), new(01800), new(01900),
        new(02000), new(02100), new(02200), new(02300), new(02400), new(02500), new(02600), new(02700), new(02800), new(02900),
        new(03000), new(03100), new(03200), new(03300), new(03400), new(03500), new(03600), new(03700), new(03800), new(03900),
        new(04000), new(04100), new(04200), new(04300), new(04400), new(04500), new(04600), new(04700), new(04800), new(04900),
        new(05000), new(05100), new(05200), new(05300), new(05400), new(05500), new(05600), new(05700), new(05800), new(05900),
        new(06000), new(06100), new(06200), new(06300), new(06400), new(06500), new(06600), new(06700), new(06800), new(06900),
        new(07000), new(07100), new(07200), new(07300), new(07400), new(07500), new(07600), new(07700), new(07800), new(07900),
        new(08000), new(08100), new(08200), new(08300), new(08400), new(08500), new(08600), new(08700), new(08800), new(08900),
        new(09000), new(09100), new(09200), new(09300), new(09400), new(09500), new(09600), new(09700), new(09800), new(09900),
        new(09000), new(09100), new(09200), new(09300), new(09400), new(09500), new(09600), new(09700), new(09800), new(09900),
        new(08000), new(08100), new(08200), new(08300), new(08400), new(08500), new(08600), new(08700), new(08800), new(08900),
        new(07000), new(07100), new(07200), new(07300), new(07400), new(07500), new(07600), new(07700), new(07800), new(07900),
        new(06000), new(06100), new(06200), new(06300), new(06400), new(06500), new(06600), new(06700), new(06800), new(06900),
        new(05000), new(05100), new(05200), new(05300), new(05400), new(05500), new(05600), new(05700), new(05800), new(05900),
        new(04000), new(04100), new(04200), new(04300), new(04400), new(04500), new(04600), new(04700), new(04800), new(04900),
        new(03000), new(03100), new(03200), new(03300), new(03400), new(03500), new(03600), new(03700), new(03800), new(03900),
        new(02000), new(02100), new(02200), new(02300), new(02400), new(02500), new(02600), new(02700), new(02800), new(02900),
        new(01000), new(01100), new(01200), new(01300), new(01400), new(01500), new(01600), new(01700), new(01800), new(01900),
        new(00000), new(00100), new(00200), new(00300), new(00400), new(00500), new(00600), new(00700), new(00800), new(00900),
        new(-00000), new(-00100), new(-00200), new(-00300), new(-00400), new(-00500), new(-00600), new(-00700), new(-00800), new(-00900),
        new(-01000), new(-01100), new(-01200), new(-01300), new(-01400), new(-01500), new(-01600), new(-01700), new(-01800), new(-01900),
        new(-02000), new(-02100), new(-02200), new(-02300), new(-02400), new(-02500), new(-02600), new(-02700), new(-02800), new(-02900),
        new(-03000), new(-03100), new(-03200), new(-03300), new(-03400), new(-03500), new(-03600), new(-03700), new(-03800), new(-03900),
        new(-04000), new(-04100), new(-04200), new(-04300), new(-04400), new(-04500), new(-04600), new(-04700), new(-04800), new(-04900),
        new(-05000), new(-05100), new(-05200), new(-05300), new(-05400), new(-05500), new(-05600), new(-05700), new(-05800), new(-05900),
        new(-06000), new(-06100), new(-06200), new(-06300), new(-06400), new(-06500), new(-06600), new(-06700), new(-06800), new(-06900),
        new(-07000), new(-07100), new(-07200), new(-07300), new(-07400), new(-07500), new(-07600), new(-07700), new(-07800), new(-07900),
        new(-08000), new(-08100), new(-08200), new(-08300), new(-08400), new(-08500), new(-08600), new(-08700), new(-08800), new(-08900),
        new(-09000), new(-09100), new(-09200), new(-09300), new(-09400), new(-09500), new(-09600), new(-09700), new(-09800), new(-09900),
        new(-09000), new(-09100), new(-09200), new(-09300), new(-09400), new(-09500), new(-09600), new(-09700), new(-09800), new(-09900),
        new(-08000), new(-08100), new(-08200), new(-08300), new(-08400), new(-08500), new(-08600), new(-08700), new(-08800), new(-08900),
        new(-07000), new(-07100), new(-07200), new(-07300), new(-07400), new(-07500), new(-07600), new(-07700), new(-07800), new(-07900),
        new(-06000), new(-06100), new(-06200), new(-06300), new(-06400), new(-06500), new(-06600), new(-06700), new(-06800), new(-06900),
        new(-05000), new(-05100), new(-05200), new(-05300), new(-05400), new(-05500), new(-05600), new(-05700), new(-05800), new(-05900),
        new(-04000), new(-04100), new(-04200), new(-04300), new(-04400), new(-04500), new(-04600), new(-04700), new(-04800), new(-04900),
        new(-03000), new(-03100), new(-03200), new(-03300), new(-03400), new(-03500), new(-03600), new(-03700), new(-03800), new(-03900),
        new(-02000), new(-02100), new(-02200), new(-02300), new(-02400), new(-02500), new(-02600), new(-02700), new(-02800), new(-02900),
        new(-01000), new(-01100), new(-01200), new(-01300), new(-01400), new(-01500), new(-01600), new(-01700), new(-01800), new(-01900),
        new(-00000), new(-00100), new(-00200), new(-00300), new(-00400), new(-00500), new(-00600), new(-00700), new(-00800), new(-00900),
        new(00000), new(00100), new(00200), new(00300), new(00400), new(00500), new(00600), new(00700), new(00800), new(00900),
        new(01000), new(01100), new(01200), new(01300), new(01400), new(01500), new(01600), new(01700), new(01800), new(01900),
        new(02000), new(02100), new(02200), new(02300), new(02400), new(02500), new(02600), new(02700), new(02800), new(02900),
        new(03000), new(03100), new(03200), new(03300), new(03400), new(03500), new(03600), new(03700), new(03800), new(03900),
        new(04000), new(04100), new(04200), new(04300), new(04400), new(04500), new(04600), new(04700), new(04800), new(04900),
        new(05000), new(05100), new(05200), new(05300), new(05400), new(05500), new(05600), new(05700), new(05800), new(05900),
        new(06000), new(06100), new(06200), new(06300), new(06400), new(06500), new(06600), new(06700), new(06800), new(06900),
        new(07000), new(07100), new(07200), new(07300), new(07400), new(07500), new(07600), new(07700), new(07800), new(07900),
        new(08000), new(08100), new(08200), new(08300), new(08400), new(08500), new(08600), new(08700), new(08800), new(08900),
        new(09000), new(09100), new(09200), new(09300), new(09400), new(09500), new(09600), new(09700), new(09800), new(09900),
        new(09000), new(09100), new(09200), new(09300), new(09400), new(09500), new(09600), new(09700), new(09800), new(09900),
        new(08000), new(08100), new(08200), new(08300), new(08400), new(08500), new(08600), new(08700), new(08800), new(08900),
        new(07000), new(07100), new(07200), new(07300), new(07400), new(07500), new(07600), new(07700), new(07800), new(07900),
        new(06000), new(06100), new(06200), new(06300), new(06400), new(06500), new(06600), new(06700), new(06800), new(06900),
        new(05000), new(05100), new(05200), new(05300), new(05400), new(05500), new(05600), new(05700), new(05800), new(05900),
        new(04000), new(04100), new(04200), new(04300), new(04400), new(04500), new(04600), new(04700), new(04800), new(04900),
        new(03000), new(03100), new(03200), new(03300), new(03400), new(03500), new(03600), new(03700), new(03800), new(03900),
        new(02000), new(02100), new(02200), new(02300), new(02400), new(02500), new(02600), new(02700), new(02800), new(02900),
        new(01000), new(01100), new(01200), new(01300), new(01400), new(01500), new(01600), new(01700), new(01800), new(01900),
        new(00000), new(00100), new(00200), new(00300), new(00400), new(00500), new(00600), new(00700), new(00800), new(00900),
        new(-00000), new(-00100), new(-00200), new(-00300), new(-00400), new(-00500), new(-00600), new(-00700), new(-00800), new(-00900),
        new(-01000), new(-01100), new(-01200), new(-01300), new(-01400), new(-01500), new(-01600), new(-01700), new(-01800), new(-01900),
        new(-02000), new(-02100), new(-02200), new(-02300), new(-02400), new(-02500), new(-02600), new(-02700), new(-02800), new(-02900),
        new(-03000), new(-03100), new(-03200), new(-03300), new(-03400), new(-03500), new(-03600), new(-03700), new(-03800), new(-03900),
        new(-04000), new(-04100), new(-04200), new(-04300), new(-04400), new(-04500), new(-04600), new(-04700), new(-04800), new(-04900),
        new(-05000), new(-05100), new(-05200), new(-05300), new(-05400), new(-05500), new(-05600), new(-05700), new(-05800), new(-05900),
        new(-06000), new(-06100), new(-06200), new(-06300), new(-06400), new(-06500), new(-06600), new(-06700), new(-06800), new(-06900),
        new(-07000), new(-07100), new(-07200), new(-07300), new(-07400), new(-07500), new(-07600), new(-07700), new(-07800), new(-07900),
        new(-08000), new(-08100), new(-08200), new(-08300), new(-08400), new(-08500), new(-08600), new(-08700), new(-08800), new(-08900),
        new(-09000), new(-09100), new(-09200), new(-09300), new(-09400), new(-09500), new(-09600), new(-09700), new(-09800), new(-09900),
        new(-09000), new(-09100), new(-09200), new(-09300), new(-09400), new(-09500), new(-09600), new(-09700), new(-09800), new(-09900),
        new(-08000), new(-08100), new(-08200), new(-08300), new(-08400), new(-08500), new(-08600), new(-08700), new(-08800), new(-08900),
        new(-07000), new(-07100), new(-07200), new(-07300), new(-07400), new(-07500), new(-07600), new(-07700), new(-07800), new(-07900),
        new(-06000), new(-06100), new(-06200), new(-06300), new(-06400), new(-06500), new(-06600), new(-06700), new(-06800), new(-06900),
        new(-05000), new(-05100), new(-05200), new(-05300), new(-05400), new(-05500), new(-05600), new(-05700), new(-05800), new(-05900),
        new(-04000), new(-04100), new(-04200), new(-04300), new(-04400), new(-04500), new(-04600), new(-04700), new(-04800), new(-04900),
        new(-03000), new(-03100), new(-03200), new(-03300), new(-03400), new(-03500), new(-03600), new(-03700), new(-03800), new(-03900),
        new(-02000), new(-02100), new(-02200), new(-02300), new(-02400), new(-02500), new(-02600), new(-02700), new(-02800), new(-02900),
        new(-01000), new(-01100), new(-01200), new(-01300), new(-01400), new(-01500), new(-01600), new(-01700), new(-01800), new(-01900),
        new(-00000), new(-00100), new(-00200), new(-00300), new(-00400), new(-00500), new(-00600), new(-00700), new(-00800), new(-00900),
        new(00000), new(00100), new(00200), new(00300), new(00400), new(00500), new(00600), new(00700), new(00800), new(00900),
        new(01000), new(01100), new(01200), new(01300), new(01400), new(01500), new(01600), new(01700), new(01800), new(01900),
        new(02000), new(02100), new(02200), new(02300), new(02400), new(02500), new(02600), new(02700), new(02800), new(02900),
        new(03000), new(03100), new(03200), new(03300), new(03400), new(03500), new(03600), new(03700), new(03800), new(03900),
        new(04000), new(04100), new(04200), new(04300), new(04400), new(04500), new(04600), new(04700), new(04800), new(04900),
        new(05000), new(05100), new(05200), new(05300), new(05400), new(05500), new(05600), new(05700), new(05800), new(05900),
        new(06000), new(06100), new(06200), new(06300), new(06400), new(06500), new(06600), new(06700), new(06800), new(06900),
        new(07000), new(07100), new(07200), new(07300), new(07400), new(07500), new(07600), new(07700), new(07800), new(07900),
        new(08000), new(08100), new(08200), new(08300), new(08400), new(08500), new(08600), new(08700), new(08800), new(08900),
        new(09000), new(09100), new(09200), new(09300), new(09400), new(09500), new(09600), new(09700), new(09800), new(09900),
        new(09000), new(09100), new(09200), new(09300), new(09400), new(09500), new(09600), new(09700), new(09800), new(09900),
        new(08000), new(08100), new(08200), new(08300), new(08400), new(08500), new(08600), new(08700), new(08800), new(08900),
        new(07000), new(07100), new(07200), new(07300), new(07400), new(07500), new(07600), new(07700), new(07800), new(07900),
        new(06000), new(06100), new(06200), new(06300), new(06400), new(06500), new(06600), new(06700), new(06800), new(06900),
        new(05000), new(05100), new(05200), new(05300), new(05400), new(05500), new(05600), new(05700), new(05800), new(05900),
        new(04000), new(04100), new(04200), new(04300), new(04400), new(04500), new(04600), new(04700), new(04800), new(04900),
        new(03000), new(03100), new(03200), new(03300), new(03400), new(03500), new(03600), new(03700), new(03800), new(03900),
        new(02000), new(02100), new(02200), new(02300), new(02400), new(02500), new(02600), new(02700), new(02800), new(02900),
        new(01000), new(01100), new(01200), new(01300), new(01400), new(01500), new(01600), new(01700), new(01800), new(01900),
        new(00000), new(00100), new(00200), new(00300), new(00400), new(00500), new(00600), new(00700), new(00800), new(00900),
        new(-00000), new(-00100), new(-00200), new(-00300), new(-00400), new(-00500), new(-00600), new(-00700), new(-00800), new(-00900),
        new(-01000), new(-01100), new(-01200), new(-01300), new(-01400), new(-01500), new(-01600), new(-01700), new(-01800), new(-01900),
        new(-02000), new(-02100), new(-02200), new(-02300), new(-02400), new(-02500), new(-02600), new(-02700), new(-02800), new(-02900),
        new(-03000), new(-03100), new(-03200), new(-03300), new(-03400), new(-03500), new(-03600), new(-03700), new(-03800), new(-03900),
        new(-04000), new(-04100), new(-04200), new(-04300), new(-04400), new(-04500), new(-04600), new(-04700), new(-04800), new(-04900),
        new(-05000), new(-05100), new(-05200), new(-05300), new(-05400), new(-05500), new(-05600), new(-05700), new(-05800), new(-05900),
        new(-06000), new(-06100), new(-06200), new(-06300), new(-06400), new(-06500), new(-06600), new(-06700), new(-06800), new(-06900),
        new(-07000), new(-07100), new(-07200), new(-07300), new(-07400), new(-07500), new(-07600), new(-07700), new(-07800), new(-07900),
        new(-08000), new(-08100), new(-08200), new(-08300), new(-08400), new(-08500), new(-08600), new(-08700), new(-08800), new(-08900),
        new(-09000), new(-09100), new(-09200), new(-09300), new(-09400), new(-09500), new(-09600), new(-09700), new(-09800), new(-09900),
        new(-09000), new(-09100), new(-09200), new(-09300), new(-09400), new(-09500), new(-09600), new(-09700), new(-09800), new(-09900),
        new(-08000), new(-08100), new(-08200), new(-08300), new(-08400), new(-08500), new(-08600), new(-08700), new(-08800), new(-08900),
        new(-07000), new(-07100), new(-07200), new(-07300), new(-07400), new(-07500), new(-07600), new(-07700), new(-07800), new(-07900),
        new(-06000), new(-06100), new(-06200), new(-06300), new(-06400), new(-06500), new(-06600), new(-06700), new(-06800), new(-06900),
        new(-05000), new(-05100), new(-05200), new(-05300), new(-05400), new(-05500), new(-05600), new(-05700), new(-05800), new(-05900),
        new(-04000), new(-04100), new(-04200), new(-04300), new(-04400), new(-04500), new(-04600), new(-04700), new(-04800), new(-04900),
        new(-03000), new(-03100), new(-03200), new(-03300), new(-03400), new(-03500), new(-03600), new(-03700), new(-03800), new(-03900),
        new(-02000), new(-02100), new(-02200), new(-02300), new(-02400), new(-02500), new(-02600), new(-02700), new(-02800), new(-02900),
        new(-01000), new(-01100), new(-01200), new(-01300), new(-01400), new(-01500), new(-01600), new(-01700), new(-01800), new(-01900),
        new(-00000), new(-00100), new(-00200), new(-00300), new(-00400), new(-00500), new(-00600), new(-00700), new(-00800), new(-00900),
        new(00000), new(00100), new(00200), new(00300), new(00400), new(00500), new(00600), new(00700), new(00800), new(00900),
        new(01000), new(01100), new(01200), new(01300), new(01400), new(01500), new(01600), new(01700), new(01800), new(01900),
        new(02000), new(02100), new(02200), new(02300), new(02400), new(02500), new(02600), new(02700), new(02800), new(02900),
        new(03000), new(03100), new(03200), new(03300), new(03400), new(03500), new(03600), new(03700), new(03800), new(03900),
        new(04000), new(04100), new(04200), new(04300), new(04400), new(04500), new(04600), new(04700), new(04800), new(04900),
        new(05000), new(05100), new(05200), new(05300), new(05400), new(05500), new(05600), new(05700), new(05800), new(05900),
        new(06000), new(06100), new(06200), new(06300), new(06400), new(06500), new(06600), new(06700), new(06800), new(06900),
        new(07000), new(07100), new(07200), new(07300), new(07400), new(07500), new(07600), new(07700), new(07800), new(07900),
        new(08000), new(08100), new(08200), new(08300), new(08400), new(08500), new(08600), new(08700), new(08800), new(08900),
        new(09000), new(09100), new(09200), new(09300), new(09400), new(09500), new(09600), new(09700), new(09800), new(09900),
        new(09000), new(09100), new(09200), new(09300), new(09400), new(09500), new(09600), new(09700), new(09800), new(09900),
        new(08000), new(08100), new(08200), new(08300), new(08400), new(08500), new(08600), new(08700), new(08800), new(08900),
        new(07000), new(07100), new(07200), new(07300), new(07400), new(07500), new(07600), new(07700), new(07800), new(07900),
        new(06000), new(06100), new(06200), new(06300), new(06400), new(06500), new(06600), new(06700), new(06800), new(06900),
        new(05000), new(05100), new(05200), new(05300), new(05400), new(05500), new(05600), new(05700), new(05800), new(05900),
        new(04000), new(04100), new(04200), new(04300), new(04400), new(04500), new(04600), new(04700), new(04800), new(04900),
        new(03000), new(03100), new(03200), new(03300), new(03400), new(03500), new(03600), new(03700), new(03800), new(03900),
        new(02000), new(02100), new(02200), new(02300), new(02400), new(02500), new(02600), new(02700), new(02800), new(02900),
        new(01000), new(01100), new(01200), new(01300), new(01400), new(01500), new(01600), new(01700), new(01800), new(01900),
        new(00000), new(00100), new(00200), new(00300), new(00400), new(00500), new(00600), new(00700), new(00800), new(00900),
        new(-00000), new(-00100), new(-00200), new(-00300), new(-00400), new(-00500), new(-00600), new(-00700), new(-00800), new(-00900),
        new(-01000), new(-01100), new(-01200), new(-01300), new(-01400), new(-01500), new(-01600), new(-01700), new(-01800), new(-01900),
        new(-02000), new(-02100), new(-02200), new(-02300), new(-02400), new(-02500), new(-02600), new(-02700), new(-02800), new(-02900),
        new(-03000), new(-03100), new(-03200), new(-03300), new(-03400), new(-03500), new(-03600), new(-03700), new(-03800), new(-03900),
        new(-04000), new(-04100), new(-04200), new(-04300), new(-04400), new(-04500), new(-04600), new(-04700), new(-04800), new(-04900),
        new(-05000), new(-05100), new(-05200), new(-05300), new(-05400), new(-05500), new(-05600), new(-05700), new(-05800), new(-05900),
        new(-06000), new(-06100), new(-06200), new(-06300), new(-06400), new(-06500), new(-06600), new(-06700), new(-06800), new(-06900),
        new(-07000), new(-07100), new(-07200), new(-07300), new(-07400), new(-07500), new(-07600), new(-07700), new(-07800), new(-07900),
        new(-08000), new(-08100), new(-08200), new(-08300), new(-08400), new(-08500), new(-08600), new(-08700), new(-08800), new(-08900),
        new(-09000), new(-09100), new(-09200), new(-09300), new(-09400), new(-09500), new(-09600), new(-09700), new(-09800), new(-09900),
        new(-09000), new(-09100), new(-09200), new(-09300), new(-09400), new(-09500), new(-09600), new(-09700), new(-09800), new(-09900),
        new(-08000), new(-08100), new(-08200), new(-08300), new(-08400), new(-08500), new(-08600), new(-08700), new(-08800), new(-08900),
        new(-07000), new(-07100), new(-07200), new(-07300), new(-07400), new(-07500), new(-07600), new(-07700), new(-07800), new(-07900),
        new(-06000), new(-06100), new(-06200), new(-06300), new(-06400), new(-06500), new(-06600), new(-06700), new(-06800), new(-06900),
        new(-05000), new(-05100), new(-05200), new(-05300), new(-05400), new(-05500), new(-05600), new(-05700), new(-05800), new(-05900),
        new(-04000), new(-04100), new(-04200), new(-04300), new(-04400), new(-04500), new(-04600), new(-04700), new(-04800), new(-04900),
        new(-03000), new(-03100), new(-03200), new(-03300), new(-03400), new(-03500), new(-03600), new(-03700), new(-03800), new(-03900),
        new(-02000), new(-02100), new(-02200), new(-02300), new(-02400), new(-02500), new(-02600), new(-02700), new(-02800), new(-02900),
        new(-01000), new(-01100), new(-01200), new(-01300), new(-01400), new(-01500), new(-01600), new(-01700), new(-01800), new(-01900),
        new(-00000), new(-00100), new(-00200), new(-00300), new(-00400), new(-00500), new(-00600), new(-00700), new(-00800), new(-00900),

    };

    private static Sample[] TestShape3 = Sample.FromBytesMultiple(F.ReadAllBytes(Path)[0x2C..], true);

    public static void AudioTest()
    {
        Engine.Frequency = 15;
        Engine.uncapped = false;
        Screen.position = new(0, 0);
        Screen.Size = new(50, 50);
        Screen.Scale = 8f;
        Screen.OneToOne = true;
        Screen.FullScreen = false;
        Debug.DrawDebug = true;

        window = new("Test Window", 100, 100, true);
        
        Scene scene = AudioObjectTest();
        Engine.SceneList.Add(scene);
        Engine.SceneList.ActiveScene = scene.Name;

        //Engine.Frame();
        //Sample[] samples = Speakers.GetFrame();
        //Console.WriteLine(samples.Length);
        //Console.WriteLine(string.Join(',', samples));
        //F.WriteAllBytes($"AudioTest", Sample.GetBytes(samples, true));
        
        audioOutput = new();
        window.Start();
        audioOutput.Shutdown();
    }

    private static Scene AudioObjectTest()
    {
        Scene scene = new(TestScene)
        {
            ClearMode = Screen.ClearModes.Fill,
            bgColor = 0x404080FF,
        };

        AudioChannel channel = new AudioChannel(new("TstChnl", 0))
        {
            Scene = scene,
            //audible = false,
            //monophonic = true,
            //blendAll = false,
            //volume = 0.1f,
            //leftVolume = 0f,
            //rightVolume = 0f,
            //panning = 0.5f,
        };

        new DebugController(window)
        {
            Scene = scene,
            printFrameInfo = true,
        };

        new SampleSourceTest()
        {
            Scene = scene,
            drawPosition = true,
            channel = channel,
            audible = false,
            loop = true,
            //exceedMaxVolume = true,
            //mono = true,
            //swapStereo = true,
            //volume = 100f,
            //leftVolume = 0f,
            //rightVolume = 0.25f,
            //panning = -0.75f,
            maxVolumeDistance = 20f,
            minVolumeDistance = 50f,
            waveShape = TestShape3,
        }.listeners.Add(new DebugSetPiece(new("SetPiec", 0))
        {
            Scene = scene,
            drawPosition = true,
            positionColor = DebugColors.Cyan,
            visible = false,
        });
        
        return scene;
    }

    private sealed class SampleSourceTest : SampleSource
    {
        private static int i = 0;
        
        public SampleSourceTest() : base(new("SmplSrc", (byte)i++)) { }

        protected override void PreFrame()
        {
            KeyboardMouseDevice kbm = window.kbdMouse;
            if (kbm.P.ChangedTrue) audible = true;
            else if (kbm.E.ChangedTrue) exceedMaxVolume = !exceedMaxVolume;
            else if (kbm.M.ChangedTrue) mono = !mono;
            else if (kbm.S.ChangedTrue) swapStereo = !swapStereo;
            else if (kbm.L.ChangedTrue) leftVolume = leftVolume == 0f ? 1f : 0f;
            else if (kbm.R.ChangedTrue) rightVolume = rightVolume == 0f ? 1f : 0f;
        }
    }
}