using Store.Common.EventArgs;
using System.Threading.Tasks;

namespace Store.Common.Delegates
{
    public delegate Task UploadFileEventHandler(object sender, UploadFileEventArgs args);
}
