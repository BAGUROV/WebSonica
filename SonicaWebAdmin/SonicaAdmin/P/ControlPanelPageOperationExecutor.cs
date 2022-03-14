using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using SonicaWebAdmin.SonicaAdmin.Control.Operations;

namespace SonicaWebAdmin.SonicaAdmin.P
{
    public class ControlPanelPageOperationExecutor
    {
        private object _currentOperationOrNull;

        public ControlPanelPageOperationExecutor(
            //PanelMessageViewModel message
            )
        {
            //Message = message;
        }

        public object CurrentOperationOrNull
        {
            get => _currentOperationOrNull;
            private set { _currentOperationOrNull = value; }
        }

        //public PanelMessageViewModel Message { get; }

        public async Task<OperationResult> ExecuteOpAsync(AvtukOperationViewModel op)
        {
            CurrentOperationOrNull = op;
            if (op == null)
                return null;
            OperationResult result = null;
            try
            {
                result = op.ExecuteAsync();
                switch (result)
                {
                    case OperationResult.FailedResult failed:
                        //Message.Show(PanelMessageViewModel.MessageType.Fail,failed.ErrorMessage);
                        CurrentOperationOrNull = null;
                        break;
                    case OperationResult.FailedButCanRetryResult failedButCanRetry:
                        //Message.Hide();
                        //CurrentOperationOrNull = new OperationFailedViewModel(
                        //    //Операция, которую нужно повторить. По ее типу выбирается вьюха
                        //    operationForRetry: op,
                        //    //Ошибка, которая привела к провалу
                        //    error: failedButCanRetry.ErrorMessage,
                        //    //Передаем колбек, вызываемый, когда пользователь нажмет на отмену или повтор 
                        //    onUserInputDone: (arg) =>
                        //    {
                        //        var task = ExecuteOpAsync(arg as AvtukOperationViewModel);
                        //    });
                        break;
                    case OperationResult.SuccessfullyResult successfully:
                        //Message.Show(PanelMessageViewModel.MessageType.Succes, successfully.JoyfulMessage);
                        CurrentOperationOrNull = null;
                        break;
                    case OperationResult.ConcreteResult _:
                        //Message.Hide();
                        CurrentOperationOrNull = null;
                        break;
                    case OperationResult.CanceledResult _:
                        SetOperationCanceled();
                        break;
                }
            }
            catch (OperationCanceledException)
            {
                result = OperationResult.Canceled;
                SetOperationCanceled();
            }
            catch (Exception e)
            {
                //Message.Show(PanelMessageViewModel.MessageType.Fail, e.GetBaseException().Message);
                CurrentOperationOrNull = null;
            }
            return result;
        }

        private void SetOperationCanceled()
        {
            //Message.Show(PanelMessageViewModel.MessageType.Fail, "Операция отменена");
            CurrentOperationOrNull = null;
        }
    }
}