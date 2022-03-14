using System.Threading;
using System.Threading.Tasks;

namespace SonicaWebAdmin.SonicaAdmin.Control.Operations
{
    public abstract class AvtukOperationViewModel
    {
        private string _currentStateInfo;
        private CancellationTokenSource _cancelationSource;

        protected AvtukOperationViewModel()
        {
            _cancelationSource = new CancellationTokenSource();
        }

        private void Cancel()
        {
            _cancelationSource.Cancel();
        }

        public string CurrentStateInfo
        {
            get => _currentStateInfo;
            protected set { _currentStateInfo = value; }
        }

        public OperationResult ExecuteAsync() 
            => ExecuteAsync(_cancelationSource.Token);

        protected abstract OperationResult ExecuteAsync(CancellationToken cancellationToken);


    }
}