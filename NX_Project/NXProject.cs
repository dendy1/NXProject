using NXOpen;
using NXOpen.UF;
using NXProjectForms;
using System;

namespace NX_Project
{
    public class NXProject
    {
        private static Session _theSession;
        private static UI _theUI;

        private static UFSession _theUfSession;

        private static NXProject _theProgram;
        private static bool _isDisposeCalled;

        //------------------------------------------------------------------------------
        // Constructor
        //------------------------------------------------------------------------------
        public NXProject()
        {
            try
            {
                _theSession = Session.GetSession();
                _theUI = UI.GetUI();
                _theUfSession = UFSession.GetUFSession();
                _isDisposeCalled = false;
            }
            catch (NXException ex)
            {
                // ---- Enter your exception handling code here -----
                UI.GetUI().NXMessageBox.Show("Error", NXMessageBox.DialogType.Error, ex.Message);
            }
        }

        //------------------------------------------------------------------------------
        //  Explicit Activation
        //      This entry point is used to activate the application explicitly
        //------------------------------------------------------------------------------
        public static int Main(string[] args)
        {
            int retValue = 0;

            try
            {
                _theProgram = new NXProject();

                var detailsForm = new DetailsForm();
                detailsForm.Show();

                _theProgram.Dispose();
            }
            catch (NXException ex)
            {
                // ---- Enter your exception handling code here -----
                UI.GetUI().NXMessageBox.Show("Error", NXMessageBox.DialogType.Error, ex.Message);
            }

            return retValue;
        }

        //------------------------------------------------------------------------------
        // Following method disposes all the class members
        //------------------------------------------------------------------------------
        public void Dispose()
        {
            try
            {
                if (_isDisposeCalled == false)
                {
                    //TODO: Add your application code here 
                }

                _isDisposeCalled = true;
            }
            catch (NXException ex)
            {
                // ---- Enter your exception handling code here -----
                UI.GetUI().NXMessageBox.Show("Error", NXMessageBox.DialogType.Error, ex.Message);
            }
        }

        public static int GetUnloadOption(string arg)
        {
            //Unloads the image when the NX session terminates
            return Convert.ToInt32(Session.LibraryUnloadOption.AtTermination);
        }
    }
}
