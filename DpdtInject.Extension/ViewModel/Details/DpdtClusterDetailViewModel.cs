﻿using System.Windows.Threading;
using DpdtInject.Extension.Helper;
using DpdtInject.Extension.Shared.Dto;

namespace DpdtInject.Extension.ViewModel.Details
{
    public class DpdtClusterDetailViewModel : BaseViewModel, IDpdtClusterDetail
    {
        private readonly IDpdtClusterDetail _target;

        /// <inheritdoc />
        public string ClassNamespace
        {
            get;
        }

        /// <inheritdoc />
        public string ClassFullName
        {
            get;
        }

        /// <inheritdoc />
        public string MethodName
        {
            get;
        }

        /// <inheritdoc />
        public string FullName
        {
            get;
        }


        public DpdtClusterDetailViewModel(
            Dispatcher dispatcher,
            IDpdtClusterDetail target
            ) : base(dispatcher)
        {
            _target = target;

            ClassNamespace = target.ClassNamespace;
            ClassFullName = target.ClassFullName;
            MethodName = target.MethodName;
            FullName = target.FullName;
        }

    }
}
