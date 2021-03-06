﻿using DpdtInject.Generator.Core;
using DpdtInject.Generator.Core.TypeInfo;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Emit;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DpdtInject.Tests
{
    public class PreparatorTypeInfoContainer : TypeInfoContainer
    {
        private readonly bool _needToStoreGeneratedSources;
        private readonly string _generatedSourceFolderFullPath;

        public PreparatorTypeInfoContainer(
            Compilation compilation,
            bool needToStoreGeneratedSources,
            string generatedSourceFolderFullPath
            ) : base(compilation)
        {
            if (generatedSourceFolderFullPath is null)
            {
                throw new System.ArgumentNullException(nameof(generatedSourceFolderFullPath));
            }

            _needToStoreGeneratedSources = needToStoreGeneratedSources;
            _generatedSourceFolderFullPath = generatedSourceFolderFullPath;
        }

        protected override void AddSourcesInternal(
            ModificationDescription[] modificationDescriptions
            )
        {
            var sourceTexts = new List<SourceText>();
            foreach (var modificationDescription in modificationDescriptions)
            {
                if (_needToStoreGeneratedSources)
                {
                    var filePath = Path.Combine(_generatedSourceFolderFullPath, modificationDescription.NewFileName);

                    modificationDescription.SaveToDisk(
                        filePath
                        );
                }

                var sourceText = SourceText.From(modificationDescription.NewFileBody, Encoding.UTF8);

                sourceTexts.Add(sourceText);
            }

            UpdateCompilationWith(sourceTexts.ToArray());
        }

        /// <inheritdoc />
        protected override void AddAdditionalFileInternal(
            string xmlBody
            )
        {
            //nothing to do
        }

        public EmitResult Emit(
            string outputPath
            )
        {
            return _compilation.Emit(outputPath);
        }
    }
}
