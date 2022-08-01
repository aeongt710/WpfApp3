using AutoMapper;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Models;

namespace WpfApp3.Components
{
    public class StudentCMPBase : ComponentBase
    {
        [Parameter]
        public List<string> ListOfString { get; set; }
        //[ParameterAttribute]
        //public string? ChildData { get; set; } 
        [Parameter] public EventCallback<StudentModel> EventCallBackProperty { get; set; }
        public StudentModel StudentModelObj { get; set; } = new StudentModel();

        //[Inject]
        //public IMapper Mapper { get; set; }


        protected async Task HandleValidSubmit()
        {
            var obj = StudentModelObj;
            await EventCallBackProperty.InvokeAsync(StudentModelObj);
        }
    }

}
