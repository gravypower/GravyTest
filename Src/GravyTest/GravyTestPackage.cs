using System.ComponentModel.Design;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using EnvDTE;
using Gravypowered.GravyTest.Commands;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell;
using SimpleInjector;

namespace Gravypowered.GravyTest
{
  
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(GuidList.guidGravyTestPkgString)]
    [ProvideAutoLoad(VSConstants.UICONTEXT.SolutionExists_string)]
    public sealed class GravyTestPackage : Package
    {
        public GravyTestPackage()
        {
            Debug.WriteLine(CultureInfo.CurrentCulture.ToString(), "Entering constructor for: {0}", this);
        }

        protected override void Initialize()
        {
            Debug.WriteLine(CultureInfo.CurrentCulture.ToString(), "Entering Initialize() of: {0}", this);
            base.Initialize();

            //var dependencyContainer = new Container();

            var menuCommandService = GetService(typeof (IMenuCommandService)) as OleMenuCommandService;
            if (menuCommandService != null)
            {
                var dte = GetService(typeof(DTE)) as DTE;
                if (dte != null)
                {
                    new TestFixtureMenuCommandHandler(this, dte).AddToEventHandler(menuCommandService,
                        PkgCmdIDList.cmdidAddAnd);
                }
            }
        }
    }
}
