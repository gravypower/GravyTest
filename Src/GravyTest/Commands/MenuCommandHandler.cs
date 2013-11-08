using System;
using System.ComponentModel.Design;
using EnvDTE;
using Microsoft.VisualStudio.Shell;

namespace Gravypowered.GravyTest.Commands
{
    public abstract class MenuCommandHandler
    {
        protected readonly IServiceProvider ServiceProvider;
        protected readonly DTE AutomationObject;

        protected MenuCommandHandler(IServiceProvider serviceProvider, DTE automationObject)
        {
            ServiceProvider = serviceProvider;
            AutomationObject = automationObject;
        }

        public void AddToEventHandler(OleMenuCommandService menuCommandService, uint commandId)
        {
            menuCommandService.AddCommand(CreateMenuItem(commandId));
        }

        private OleMenuCommand CreateMenuItem(uint commandId)
        {
            var menuCommandId = new CommandID(GuidList.guidGravyTestCmdSet, (int) commandId);
            var menuItem = new OleMenuCommand(InvokeHandler, menuCommandId);
            menuItem.BeforeQueryStatus += BeforeQueryStatus;
            return menuItem;
        }

        private void BeforeQueryStatus(object sender, EventArgs eventArgs)
        {
            var command = sender as OleMenuCommand;
            if (GuardCommand(command))
                return;

            command.Visible = false;
            command.Visible = false;

            if (GuardAutomationObject(AutomationObject))
                return;

            var selection = AutomationObject.SelectedItems;
            if (GuardSelection(selection))
                return;

            BeforeQueryStatus(command, selection);
        }

        protected abstract void BeforeQueryStatus(OleMenuCommand command, SelectedItems selection);
        protected abstract void Invoke(OleMenuCommand command, SelectedItems selection);

        

        private void InvokeHandler(object sender, EventArgs eventArgs)
        {
            var command = (OleMenuCommand)sender;

            if (GuardAutomationObject(AutomationObject))
                return;

            var selection = AutomationObject.SelectedItems;
            if (GuardSelection(selection))
                return;

            Invoke(command, selection);
        }

        protected virtual bool GuardSelection(SelectedItems selection)
        {
            return selection == null;
        }

        protected virtual bool GuardAutomationObject(DTE automationObject)
        {
            return automationObject == null;
        }

        protected virtual bool GuardCommand(OleMenuCommand command)
        {
            return command == null;
        }

        
    }
}
