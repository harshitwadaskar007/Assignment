using APIAssignment.Pages;
using APIAssignment.Steps;
using APIAssignment.Utilities;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAssignment.Assignment
{
    public class API_ObjectFactory
    {
        public static CommonFunctions common;

        Lazy<GenericAPI_Fucntions> lazyGenericAPI_Fucntions = new Lazy<GenericAPI_Fucntions>(() =>
        {
            GenericAPI_Fucntions internalObject = new GenericAPI_Fucntions();
            return internalObject;
        });
        public GenericAPI_Fucntions genericAPI_Fucntions { get { return lazyGenericAPI_Fucntions.Value; } }
    }
}
