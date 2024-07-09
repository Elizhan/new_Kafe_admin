using CV19.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV19.Infrastructure.Commands
{
   internal class LambdaCommand:Command
    {
        private readonly Action<object> _Execate;
        private readonly Func<object,bool> _CanExecate;
        public LambdaCommand(Action<object> Execate, Func<object,bool> CanExecate=null)
        {
            _Execate = Execate ?? throw new ArgumentNullException(nameof(Execate)); 
            _CanExecate = CanExecate;
        }
        
        public override bool CanExecute(object parameter) => _CanExecate?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Execate(parameter);
    }
}
