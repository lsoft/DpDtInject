﻿using DpdtInject.Extension.Shared;
using DpdtInject.Extension.UI.Control;
using DpdtInject.Extension.UI.ViewModel.Add;
using System;
using System.Windows.Controls;
using Task = System.Threading.Tasks.Task;

namespace DpdtInject.Extension.UI.ChainStep
{
    public class BindsFromChainStep : MedianeChainStep, IChainStep
    {
        private readonly ContentControl _targetControl;
        private readonly ChoosedParameters _choosedParameters;
        public BindsFromChainStep(
            ContentControl targetControl,
            ChoosedParameters choosedParameters
            )
        {
            if (targetControl is null)
            {
                throw new ArgumentNullException(nameof(targetControl));
            }

            if (choosedParameters is null)
            {
                throw new ArgumentNullException(nameof(choosedParameters));
            }

            _targetControl = targetControl;
            _choosedParameters = choosedParameters;
        }


        public async Task CreateAsync()
        {
            var v = new BindsFromControl();

            var vm = new BindsFromViewModel(
                _choosedParameters,
                PreviousAsync,
                NextAsync
                );

            v.DataContext = vm;
            _targetControl.Content = v;

            try
            {
                await vm!.StartAsync();
            }
            catch (Exception excp)
            {
                _targetControl.Content = excp.Message + Environment.NewLine + excp.StackTrace;
                Logging.LogVS(excp);
            }
        }

    }
}
