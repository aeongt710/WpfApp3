using AutoMapper;
using GraphQL;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
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
        public async Task GQLAsync()
        {
            GraphQLHttpClient _graphqlClient =
               new GraphQLHttpClient("https://graphqlv2.jmmtest.xyz/graphql", new NewtonsoftJsonSerializer());
            _graphqlClient.HttpClient.DefaultRequestHeaders.Add("Authorization", "bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjllODJhOGJiLTUwNWYtNGYwNS04Nzc5LWNkNjlmNmMwYTNjMSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJhZG1pbiIsInRlbmFudCI6Imh5c2FiYXQiLCJleHAiOjE2NTkzNTUxODksImlzcyI6Imh0dHBzOi8vZ3JhcGhxbC5qbW10ZXN0Lnh5eiIsImF1ZCI6Imh0dHBzOi8vZ2FycGhxbC5qbW10ZXN0Lnh5eiJ9.H21eSWeb54lgVTC6f73LC7fQen6CMxVhxzd_xQVdtBQ");

            GraphQLRequest _fetchCountriesQuery = new GraphQLRequest
            {
                Query = @"
                        query {
                          customers {
                            nodes{
                              nameEnglish 
                              contact
                            }
                          }
                        }
        "
            };

            var fetchQuery = await _graphqlClient.SendQueryAsync<GraphQL2>(_fetchCountriesQuery);
        }

        protected async Task HandleValidSubmit()
        {
            var obj = StudentModelObj;
            await GQLAsync();
            await EventCallBackProperty.InvokeAsync(StudentModelObj);
        }
    }

}
