// Guids.cs
// MUST match guids.h
using System;

namespace Gravypowered.GravyTest
{
    static class GuidList
    {
        public const string guidGravyTestPkgString = "5e57d0e5-292d-4143-b3e1-d66c0ce90063";
        public const string guidGravyTestCmdSetString = "cca2c543-5ea1-4532-b7b7-88aa3f86ce0a";
        public const string guidToolWindowPersistanceString = "bd37c557-f4c5-417c-b257-ce911dbb2cba";

        public static readonly Guid guidGravyTestCmdSet = new Guid(guidGravyTestCmdSetString);
    };
}