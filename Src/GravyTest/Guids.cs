// Guids.cs
// MUST match guids.h
using System;

namespace Gravypowered.GravyTest
{
    static class GuidList
    {
        public const string guidGravyTestPkgString = "245666e7-b4e2-4a39-a349-f4b5c218974a";
        public const string guidGravyTestCmdSetString = "547938d2-b887-4d91-92ac-b6563c9d9e88";

        public static readonly Guid guidGravyTestCmdSet = new Guid(guidGravyTestCmdSetString);
    };
}