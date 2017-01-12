namespace MathWindowsServiceHost
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LocalSystem = new System.ServiceProcess.ServiceProcessInstaller();
            this.MathService = new System.ServiceProcess.ServiceInstaller();
            // 
            // LocalSystem
            // 
            this.LocalSystem.Password = null;
            this.LocalSystem.Username = null;
            // 
            // MathService
            // 
            this.MathService.Description = "this is the math service!";
            this.MathService.DisplayName = "MathService";
            this.MathService.ServiceName = "MathService";
            this.MathService.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.LocalSystem,
            this.MathService});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller LocalSystem;
        private System.ServiceProcess.ServiceInstaller MathService;
    }
}