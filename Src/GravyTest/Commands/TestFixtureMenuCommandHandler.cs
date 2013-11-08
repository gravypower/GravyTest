using System;
using EnvDTE;

namespace Gravypowered.GravyTest.Commands
{
    public class TestFixtureMenuCommandHandler : MenuCommandHandler
    {
        public TestFixtureMenuCommandHandler(IServiceProvider serviceProvider, DTE automationObject) : base(serviceProvider, automationObject)
        {
        }

        protected override void Invoke(Microsoft.VisualStudio.Shell.OleMenuCommand command, SelectedItems selectedItems)
        {
            System.Windows.MessageBox.Show("Command executed");
        }

        protected override void BeforeQueryStatus(Microsoft.VisualStudio.Shell.OleMenuCommand command, SelectedItems selectedItems)
        {
            if(selectedItems.Count > 1)
                return;
            var selectedItem = selectedItems.Item(1);

            if(selectedItem == null)
                return;

            if(!selectedItem.Name.ToLowerInvariant().Contains("testfixture.cs"))
                return;

            command.Visible = true;
            command.Enabled = true;
        }
    }
}
