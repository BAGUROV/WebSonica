using System.Threading;
using System.Threading.Tasks;
using SonicaWebAdmin.Models.Avtuk;

namespace SonicaWebAdmin.SonicaAdmin.Control.Operations
{
    public class RestartOperationViewModel : AvtukOperationViewModel
    {
        private readonly AvtukModel _avtuk;

        public RestartOperationViewModel(AvtukModel avtuk)
        {
            _avtuk = avtuk;
        }

        protected override OperationResult ExecuteAsync(CancellationToken cancellationToken)
        {
            CurrentStateInfo = "Перезапускаем";
            if (_avtuk.TryRestartAsync())
                return OperationResult.Failed("При перезапуске устройства что то пошло не так");
            return OperationResult.Successfully("Устройство будет перезапущено.");
        }
    }
}