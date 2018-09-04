using Store.Common.EventArgs;
using System.Threading.Tasks;

namespace Store.Common.Delegates
{
    public delegate Task UploadAllFilesEventHandler(object sender, UploadAllFilesEventArgs args);
}
