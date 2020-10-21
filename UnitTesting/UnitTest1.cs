using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Models.Models;
using Microsoft.EntityFrameworkCore;
using DataAccess.DataAccess;
using p2API.Controllers;
using Microsoft.AspNetCore.Mvc;
using RestSharp.Extensions;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Identity;
using Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Testing;

namespace UnitTesting
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<p2API.Startup>>
    {

        private readonly WebApplicationFactory<p2API.Startup> _factory;

        public UnitTest1(WebApplicationFactory<p2API.Startup> factory)
        {
            _factory = factory;
        }

        [Theory(Skip = "e2e")]
        [InlineData("/")]
        public async Task Get_EndpointReturnSuccess(string url)
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
            Assert.Equal("text/html; charset=utf-8", response.Content.Headers
                .ContentType.ToString());
        }

        [Fact]
        public async void TestReturnProjectFromDb()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test")
                .Options;

            using (var context = new Databasecontext(options))
            {
                context.Projects.Add(new Project("user", DateTime.Now, DateTime.Now, 1.00, "test", "test")
                {
                    ProjectId = 1,
                    UserId = "1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    PaymentOffered = 1.00,
                    ProjectName = "test",
                    Description = "test"



                });

                ProjectsController projectController = new ProjectsController(context);
                context.SaveChanges();
                var project = await projectController.GetProject(1);
                Project result = project.Value;
                Assert.Equal(1, result.ProjectId);
                Assert.Equal(1.00, result.PaymentOffered);
            }









        }
        [Fact]
        public async void TestReturnProjectsFromDb()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test2")
                .Options;

            using (var context = new Databasecontext(options))
            {

                context.Projects.Add(new Project("user", DateTime.Now, DateTime.Now, 1.00, "test", "test")
                {
                    ProjectId = 2,
                    UserId = "1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    PaymentOffered = 1.00,
                    ProjectName = "test",
                    Description = "test"



                });

                context.SaveChanges();

                ProjectsController projectController = new ProjectsController(context);
                var project = await projectController.GetProjects();
                var result = project.Value;
                Assert.Single(result);

            }


        }


        [Fact]
        public async void TestGetLatestProjectsWithUserId()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test3")
                .Options;

            using (var context = new Databasecontext(options))
            {

                var project = new Project("user", DateTime.Now, DateTime.Now, 1.00, "test", "test")
                {
                    ProjectId = 3,
                    UserId = "1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    PaymentOffered = 1.00,
                    ProjectName = "test",
                    Description = "test"



                };
                var project2 = new Project("user", DateTime.Now, DateTime.Now, 1.00, "test", "test")
                {
                    ProjectId = 4,
                    UserId = "2",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    PaymentOffered = 1.00,
                    ProjectName = "test",
                    Description = "test"



                };

                context.Add(project);
                context.Add(project2);
                context.SaveChanges();

                ProjectsController projectController = new ProjectsController(context);
                var actionresult = await projectController.GetLatestProjectByUser("2");
                var result = (OkObjectResult)actionresult.Result;
                Project result2 = (Project) result.Value;
                //       ActionResult okObjectResult = Assert.IsAssignableFrom<ActionResult>(actionresult);
                //       Project result = Assert.IsType<Project>(okObjectResult.);
                Assert.Equal(4, result2.ProjectId);

            }



        }


        [Fact]
        public async void TestPostProject()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test4")
                .Options;

            using (var context = new Databasecontext(options))
            {

            
                var project2 = new Project("user", DateTime.Now, DateTime.Now, 1.00, "test", "test")
                {
                    ProjectId = 4,
                    UserId = "2",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    PaymentOffered = 1.00,
                    ProjectName = "test",
                    Description = "test"



                };

                ProjectsController projectController = new ProjectsController(context);
                await projectController.PostProject(project2);

                Project res = context.Projects.Find(4);
                Assert.Equal(4, res.ProjectId);

            }



        }
        [Fact]
        public async void TestDeleteProject()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test5")
                .Options;

            using (var context = new Databasecontext(options))
            {


                var project2 = new Project("user", DateTime.Now, DateTime.Now, 1.00, "test", "test")
                {
                    ProjectId = 4,
                    UserId = "2",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    PaymentOffered = 1.00,
                    ProjectName = "test",
                    Description = "test"



                };

                ProjectsController projectController = new ProjectsController(context);
                await projectController.DeleteProject(4);

                Project res = context.Projects.Find(4);
                Assert.Null(res);

            }



        }
        [Fact]
        public async void TestGetContractorProjects()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test6")
                .Options;

            using (var context = new Databasecontext(options))
            {

                var project = new Project("user", DateTime.Now, DateTime.Now, 1.00, "test", "test")
                {
                    ProjectId = 3,
                    UserId = "1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    PaymentOffered = 1.00,
                    ProjectName = "test",
                    Description = "test"



                };
                var projectpos = new ProjectPositions()
                {
                    ProjectPositionsId = 1,
                    ProjectId = 3,
                    PositionId = 1,
                    ContractorId = "1"
                    


                };

                context.Add(project);
                context.Add(projectpos);
                context.SaveChanges();

                ProjectsController projectController = new ProjectsController(context);
                var actionresult = await projectController.GetProjectByContractor("1");
                var result = (OkObjectResult)actionresult.Result;
                List<Project> result2 = (List<Project>)result.Value;
                Assert.Equal(3, result2.Last().ProjectId);

            }



        }

        [Fact]
        public async void TestGetProjectsWithUserId()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test7")
                .Options;

            using (var context = new Databasecontext(options))
            {

                var project = new Project("user", DateTime.Now, DateTime.Now, 1.00, "test", "test")
                {
                    ProjectId = 3,
                    UserId = "1",
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now,
                    PaymentOffered = 1.00,
                    ProjectName = "test",
                    Description = "test"



                };
             

                context.Add(project);
                
                context.SaveChanges();

                ProjectsController projectController = new ProjectsController(context);
                var actionresult = await projectController.GetProjectByUser("1");
                var result = (OkObjectResult)actionresult.Result;
                List<Project> result2 = (List<Project>)result.Value;
                Assert.Equal(3, result2.Last().ProjectId);

            }



        }


        [Fact]
        public async void TestReturnProjectPositionsWithId()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var projectPositions = new ProjectPositions();
                context.Add(projectPositions);
                context.SaveChanges();
                ProjectPositionsController ProjectPositions = new ProjectPositionsController(context);
                
                var project = await ProjectPositions.GetProjectPositions(1);
                ProjectPositions result = project.Value;
                Assert.Equal(1, result.ProjectPositionsId);
                
            }

        }
        [Fact]
        public async void TestReturnProjectPositions()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test2")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var projectPositions = new ProjectPositions();
                context.Add(projectPositions);
                context.SaveChanges();
                ProjectPositionsController ProjectPositions = new ProjectPositionsController(context);

                var projectpos = await ProjectPositions.GetProjectPositions();
                IEnumerable <ProjectPositions> result = projectpos.Value;
                Assert.Single(result);

            }

        }

        [Fact]
        public async void TestGetProjectPositionsByProjectId()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test3")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var projectPositions = new ProjectPositions()
                {
                    ProjectId = 1
                };
                context.Add(projectPositions);
                context.SaveChanges();
                ProjectPositionsController ProjectPositions = new ProjectPositionsController(context);

                var actionresult = await ProjectPositions.GetPositionsByProjectId(1);
                var result = (OkObjectResult)actionresult.Result;
                List<ProjectPositions> result2 = (List<ProjectPositions>)result.Value;
                Assert.Equal(1, result2.Last().ProjectId);


            }

        }
        [Fact]
        public async void TestPostProjectPositions()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test4")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var projectPositions = new ProjectPositions()
                {
                    ProjectId = 1
                };
                ProjectPositionsController ProjectPositions = new ProjectPositionsController(context);

                var actionresult = await ProjectPositions.PostProjectPositions(projectPositions);
                ProjectPositions res = context.ProjectPositions.Find(1);
                Assert.Equal(1, res.ProjectPositionsId);


            }

        }

        [Fact]
        public async void DeleteProjectPositions()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test4")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var projectPositions = new ProjectPositions()
                {
                    ProjectId = 1
                };
                ProjectPositionsController ProjectPositions = new ProjectPositionsController(context);

                context.Add(projectPositions);
                await ProjectPositions.DeleteProjectPositions(1);

                var result = context.ProjectPositions.Find(1);
                Assert.Null(result);


            }

        }




        [Fact]
        public async void TestReturnSkillsWithId()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var skill = new Skill()
                {
                    SkillId = 1,
                    SkillName = "test",
                    Description = "test"
                };
                context.Add(skill);
                context.SaveChanges();
               SkillsController Skills = new SkillsController(context);

                var skills = await Skills.GetSkill(1);
                Skill result = skills.Value;
                Assert.Equal("test", result.Description);

            }

        }

        [Fact]
        public async void TestReturnSkills()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test1")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var skill = new Skill()
                {
                    SkillId = 1,
                    SkillName = "test",
                    Description = "test"
                };
                context.Add(skill);
                context.SaveChanges();
                SkillsController Skills = new SkillsController(context);

                var skills = await Skills.GetSkills();
                IEnumerable <Skill> result = skills.Value;
                Assert.Equal("test", result.Last().Description);
                Assert.Single(result);

            }

        }
        [Fact]
        public async void TestPostSkills()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test3")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var skill = new SkillsVM()
                {
                    skillId = "1",
                    skillName = "test",
                    skillDescription = "test"
                };
                
                SkillsController Skills = new SkillsController(context);

                await Skills.PostSkill(skill);
                var find = context.Skills.Find(1);
                Assert.Equal(1, find.SkillId);

            }

        }
        [Fact]
        public async void TestDeleteSkills()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test4")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var skill = new Skill()
                {
                    SkillId = 1,
                    skillName = "test",
                    skillDescription = "test"
                };

                SkillsController Skills = new SkillsController(context);

                context.Skills.Add(skill);
                await Skills.DeleteSkill(1);
                var find = context.Skills.Find(1);
                Assert.Null(find);

            }

        }


        [Fact]
        public async void TestReturnContractors()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var contractor = new Contractor("test1", "test2", "test3", "test4", "test5");
                context.Add(contractor);
                context.SaveChanges();
                ContractorsController ContractorPositions = new ContractorsController(context);

                var contractors = await ContractorPositions.GetContractors();
                IEnumerable<Contractor> result = contractors.Value;
                Assert.Single(result);
                Assert.Equal("test1", result.Last().Username);

            }

        }
        [Fact]
        public async void TestReturnContractorId()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test2")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var contractor = new Contractor("test1", "test2", "test3", "test4", "test5");
                context.Add(contractor);
                context.SaveChanges();
                ContractorsController ContractorPositions = new ContractorsController(context);

                var contractors = await ContractorPositions.GetContractor(1);
                Contractor result = contractors.Value;
                Assert.Equal("test1", result.Username);

            }

        }
        [Fact]
        public async void TestPostContractor()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test3")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var contractor = new Contractor("test1", "test2", "test3", "test4", "test5");
               
                ContractorsController ContractorPositions = new ContractorsController(context);

                var res = await ContractorPositions.PostContractor(contractor);
                var result = context.Contractors.Find(1);
                Assert.Equal("test1", result.Username);

            }

        }
        [Fact]
        public async void TestDeleteContractor()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test4")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var contractor = new Contractor("test1", "test2", "test3", "test4", "test5");

                ContractorsController ContractorPositions = new ContractorsController(context);
                context.Add(contractor);
                context.SaveChanges();
                await ContractorPositions.DeleteContractor(1);
                var result = context.Contractors.Find(1);
                Assert.Null(result);

            }

        }
        [Fact]
        public async void TestHireRequests()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test1")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var hireRequest = new HireRequest(1, "1", "1");

                HireRequestsController HireRequests = new HireRequestsController(context);
                context.Add(hireRequest);
                context.SaveChanges();

                var hire = await HireRequests.GetHireRequests();
                IEnumerable<HireRequest> result = hire.Value;
                Assert.Single(result);
                Assert.Equal("1", result.Last().ClientId);
            }

        }

        [Fact]
        public async void TestHireRequestsid()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test2")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var hireRequest = new HireRequest(1, "1", "1");

                HireRequestsController HireRequests = new HireRequestsController(context);
                context.Add(hireRequest);
                context.SaveChanges();

                var hire = await HireRequests.GetHireRequest(1);
                HireRequest result = hire.Value;

                Assert.Equal("1", result.ClientId);
            }

        }

        [Fact]
        public async void TestClientRequests()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test4")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var hireRequest = new HireRequest(1, "1", "1");

                HireRequestsController HireRequests = new HireRequestsController(context);
                context.Add(hireRequest);
                context.SaveChanges();

                var actionresult = await HireRequests.GetClientRequest("1");
                var result = (OkObjectResult)actionresult.Result;
                List<HireRequest> result2 = (List<HireRequest>)result.Value;
                Assert.Equal("1", result2.Last().ClientId);



            }

        }

        [Fact]
        public async void TestContractorRequests()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test5")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var hireRequest = new HireRequest(1, "1", "1");

                HireRequestsController HireRequests = new HireRequestsController(context);
                context.Add(hireRequest);
                context.SaveChanges();

                var actionresult = await HireRequests.GetContractorRequest("1");
                var result = (OkObjectResult)actionresult.Result;
                List<HireRequest> result2 = (List<HireRequest>)result.Value;
                Assert.Equal("1", result2.Last().ContractorId);



            }

        }

        [Fact]
        public async void TestPostRequests()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test6")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var hireRequest = new HireRequest(1, "1", "1");

                HireRequestsController HireRequests = new HireRequestsController(context);


                await HireRequests.PostHireRequest(hireRequest);
                var result = context.HireRequests.Find(1);
                Assert.Equal("1", result.ContractorId);



            }

        }


        [Fact]
        public async void TestDeleteRequests()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test7")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var hireRequest = new HireRequest(1, "1", "1");

                HireRequestsController HireRequests = new HireRequestsController(context);
                context.Add(hireRequest);
                context.SaveChanges();
                await HireRequests.DeleteHireRequest(1);
                var result = context.HireRequests.Find(1);
                Assert.Null(result);



            }

        }


        [Fact]
        public async void TestNeedSkills()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test7")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var needskills = new PositionNeedsSkill(1, 1);

                PositionNeedsSkillsController posskill = new PositionNeedsSkillsController(context);
                context.Add(needskills);
                context.SaveChanges();
                var result = await posskill.GetPositionNeedsSkills();
                IEnumerable<PositionNeedsSkill> results = result.Value;
                Assert.Single(results);
                Assert.IsType<PositionNeedsSkill>(results.Last());



            }

        }

        [Fact]
        public async void TestNeedSkill()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test1")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var needskills = new PositionNeedsSkill(1, 1);

                PositionNeedsSkillsController posskill = new PositionNeedsSkillsController(context);
                context.Add(needskills);
                context.SaveChanges();
                var result = await posskill.GetPositionNeedsSkill(1);
                PositionNeedsSkill results = result.Value;
                Assert.Equal(1, results.PositionId);
                Assert.IsType<PositionNeedsSkill>(results);



            }

        }

        [Fact]
        public async void TestPostNeedsSkill()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test2")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var needskills = new PositionNeedsSkill(1, 1);

                PositionNeedsSkillsController posskill = new PositionNeedsSkillsController(context);

                await posskill.PostPositionNeedsSkill(needskills);
                var result = context.PositionNeedsSkills.Find(1);
                Assert.Equal(1, result.PositionId);
                Assert.IsType<PositionNeedsSkill>(result);



            }

        }
        [Fact]
        public async void TestDeleteNeedsSkill()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test3")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var needskills = new PositionNeedsSkill(1, 1);

                PositionNeedsSkillsController posskill = new PositionNeedsSkillsController(context);
                context.Add(needskills);
                context.SaveChanges();
                await posskill.DeletePositionNeedsSkill(1);
                var result = context.PositionNeedsSkills.Find(1);
                Assert.Null(result);



            }

        }

      
 

        [Fact]
        public async void TestReturnClients()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var Client = new Client("test1", "test2", "test3", "test4", "test5");
                context.Clients.Add(Client);
                context.SaveChanges();
                ClientsController ContractorPositions = new ClientsController(context);

                var clients = await ContractorPositions.GetClients();
                IEnumerable<Client> result = clients.Value;
                Assert.Single(result);
                Assert.Equal("test1", result.Last().Username);

            }

        }

        [Fact]
        public async void TestReturnClient()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test2")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var Client = new Client("test1", "test2", "test3", "test4", "test5");
                context.Clients.Add(Client);
                context.SaveChanges();
                ClientsController client = new ClientsController(context);

                var clients = await client.GetClient(1);
                Client result = clients.Value;
               
                Assert.Equal("test1", result.Username);

            }

        }



        [Fact]
        public async void TestPostClient()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test3")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var Client = new Client("test1", "test2", "test3", "test4", "test5");
                
                ClientsController client = new ClientsController(context);
                 await client.PostClient(Client);
                var result = context.Clients.Find(1);

                Assert.Equal("test1", result.Username);

            }

        }


        [Fact]
        public async void TestDeleteClient()
        {
            var options = new DbContextOptionsBuilder<Databasecontext
                >().UseInMemoryDatabase(databaseName: "Test4")
                .Options;

            using (var context = new Databasecontext(options))
            {
                var Client = new Client("test1", "test2", "test3", "test4", "test5");

                ClientsController client = new ClientsController(context);
                context.Clients.Add(Client);
                await client.DeleteClient(1);
                var result = context.Clients.Find(1);

                Assert.Null(result);

            }

        }




    }
}
