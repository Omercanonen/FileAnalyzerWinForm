using FileAnalyzerWinForm.Core;
using FileAnalyzerWinForm.DataAccess.FileReaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileAnalyzerWinForm.DataAccess
{
    public class FileReader
    { 
        private static List<IFileReader> _readers = new List<IFileReader>
        {
            new TxtFileReader(),
            new DocxFileReader(),
            new PdfFileReader()
        };

        public static IFileReader GetReader(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            var reader = _readers.FirstOrDefault(r => r.FileType.GetExtension() == extension);

            if (reader == null)
                throw new NotSupportedException($"This file not supported {extension}");

            return reader;
        }
    }
}

