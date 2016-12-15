using CommonSnappableTypes;

namespace CSharpSnapIn
{
    [CompanyInfo(CompanyName = "Google",
        CompanyUrl = "www.google.com")]
    public class CSharpModule : IAppFunctionality
    {
        void IAppFunctionality.DoIt()
        {
            System.Windows.Forms.MessageBox.Show("You have just used the C# snap-in!");
        }
    }
}
