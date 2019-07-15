using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using PolDentEx.Models;
using PolDentEx.ViewModel;

namespace PolDentEx.DocumentationGenerator
{
    public abstract class DocumentationGenerator
    {
        public abstract ReportViewModel GenerateDocumentation(Patient patient);
    }
}