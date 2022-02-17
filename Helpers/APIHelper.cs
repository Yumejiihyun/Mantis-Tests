using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mantis_Tests
{
    public class APIHelper : HelperBase
    {
        private MantisConnect.MantisConnectPortTypeClient client;
        public APIHelper(ApplicationManager application) : base(application)
        {
            client = new MantisConnect.MantisConnectPortTypeClient();
        }
        public List<ProjectData> GetProjectsList(AccountData accountData)
        {
            var list = new List<ProjectData>();
            MantisConnect.ProjectData[] existList= client.mc_projects_get_user_accessible(accountData.Username, accountData.Password);
            foreach (var project in existList)
            {
                list.Add(new ProjectData(project.name));
            }

            return list;
        }
        public void CreateNewProject(AccountData accountData, ProjectData project)
        {
            var projectAPI = new MantisConnect.ProjectData()
            {
                name = project.Name,
            };
            client.mc_project_add(accountData.Username, accountData.Password, projectAPI);
        }
    }
}
