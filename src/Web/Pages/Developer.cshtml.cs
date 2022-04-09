using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class DeveloperModel : PageModel
    {

        public List<JobExperience> JobExperiences { get; }

        public List<Review> Reviews { get; }

        public DeveloperModel()
        {
            JobExperiences =
                new List<JobExperience> {
                    new JobExperience {
                        ElementId = "tesla",
                        CompanyName = "Tesla Inc.",
                        Responsiblites =
                            new List<string> {
                                "Automate Material Requirement Planning - Materials are integral part of vehicle production. Thousands of vehicles are produced on frequent bases, This system runs different jobs to ensure there is never a shortage of material.",
                                "Development of a Task Scheduler System - A continuous long running windows background service that automates and run software jobs to handle different modules of our ERP like Material Planning, Asset Management, Purchase Order/Sales Order requirements.",
                                "Tesla Warp Authentication and Authorization - I took ownership of the project that ensures authorization and authentication of individuals to grant and revoke permission to different application modules.",
                                "Body Shop Onboarding: This system onboards Tesla partners."
                            }
                    },
                    new JobExperience {
                        ElementId = "advantasure",
                        CompanyName = "Advantasure. Formally Tessallate",
                        Responsiblites =
                            new List<string> {
                                "Worked in development team to develop and define application scope and objectives and prepare functional and/or technical specifications.",
                                "Analyzed and evaluated detail business and technical requirements.",
                                "Coding and maintaining complex components of information systems.",
                                "Implementing coding standards and code reviews.",
                                "Developing and performing system testing and fix defects identified during testing and re-execute unit tests to validate results.",
                                "Providing timely support to data information planning effort.",
                                "Maintain technical development environment and responsibility for implementation plans."
                            }
                    },
                    new JobExperience {
                        ElementId = "knight",
                        CompanyName = "Black Knight",
                        Responsiblites =
                            new List<string> {
                                "Analyzed business/technical requirements to design a solution using standard design patterns supported by the application.",
                                "Maintained development environment according to specifications of application.",
                                "Participated in project meetings with other technical staff, business owners and subject matter experts.",
                                "Video and Oral presentations of topics as related to mortgage industry, which involved Mortgage lifecycle and going Digital."
                            }
                    },
                    new JobExperience {
                        ElementId = "aviat",
                        CompanyName = "Aviat Inc",
                        Responsiblites =
                            new List<string> {
                                "Delivered global support services to telecommunication companies. Conducted onsite and remote radio troubleshooting to restore enterprise communication links at banks and over other 300 customers of leased line, microwave radio and routers.",
                                "Laid and route telecommunications network cables, impact was to establish and enable communication links in certain locations.",
                                "IP/MPLS Technology for Multi-Protocol Label Switching.",
                                "Troubleshoot LOS signals.",
                                "Training on Tellabs 7100 - a packet optical transport solution for mobile networks and leased lines with wide range of switching options and high transmission speed. Delivered global support services to telecommunication companies. Conducted onsite and remote radio troubleshooting to restore enterprise communication links at banks and over other 300 customers of leased line, microwave radio and routers."
                            }
                    },
                    new JobExperience {
                        ElementId = "antra",
                        CompanyName = "Antra",
                        Responsiblites =
                            new List<string> {
                                "Analyzed business/technical requirements to design a solution using standard design patterns supported by the application.",
                                "Maintained development environment according to specifications of application.",
                                "Participated in project meetings with other technical staff, business owners and subject matter experts.",
                                "Video and Oral presentations of topics as related to mortgage industry, which involved Mortgage lifecycle and going Digital."
                            }
                    },
                    new JobExperience {
                        ElementId = "aptech",
                        CompanyName = "Aptech",
                        Responsiblites =
                            new List<string> {
                                "Automate Material Requirement Planning - Materials are integral part of vehicle production. Thousands of vehicles are produced on frequent bases, This system runs different jobs to ensure there is never a shortage of material.",
                                "Development of a Task Scheduler System - A continuous long running windows background service that automates and run software jobs to handle different modules of our ERP like Material Planning, Asset Management, Purchase Order/Sales Order requirements.",
                                "Tesla Warp Authentication and Authorization - I took ownership of the project that ensures authorization and authentication of individuals to grant and revote permission to different application modules",
                                "Body Shop Onboarding: This system onboards Tesla partners"
                            }
                    }
                };

            Reviews =
                new List<Review> {
                    new Review {
                        ReviewedBy = "Deepa Komathukattil",
                        ReviewedPersonCompany = "Black Knight",
                        ReviewMessage =
                            "I had the pleasure of working with Tobi at Black Knight, collaborating on several team projects. " +
                            "Tobi played a lead role on our mobile development initiative. He came up with a good responsive design, " +
                            "delivered a clean implementation and at the same time managed project timelines very well. " +
                            "Tobi's development skills were crucial to the completion of the project on time. The project was well " +
                            "received and generated notable customer interest at our annual conference that year. " +
                            "He is a good team player with great people skills. " +
                            "I have confidence Tobi will do well in any job and look forward to seeing him succeed.  ",
                        CompanyLogoName = "blackknight.jpg"
                    },
                    new Review {
                        ReviewedBy = "Sandra Madigan",
                        ReviewedPersonCompany = "Black Knight",
                        ReviewMessage =
                            "Kareem was a pleasure to collaborate with here at Black Knight. His attention to detail and willingness to " +
                            "always go the extra mile helped us deliver a top notch POC that was used to gather customer feedback. ",
                        CompanyLogoName = "blackknight.jpg"
                    },
                    new Review {
                        ReviewedBy = "Chandra Reddy",
                        ReviewedPersonCompany = "Tesla Inc.",
                        ReviewMessage =
                            "You have done a commendable job since you joined Tesla. You have shown resilency and constantly looked for " +
                            "ways to improve yourself. We are thankful for all your hard work and contributions. We trust that you will " +
                            "exceed our expectations as we advance and look forwrd to working with you for many more years in the future.",
                        CompanyLogoName = "tesla.jpg"
                    },
                    new Review {
                        ReviewedBy = "Folorunso Kareem",
                        ReviewedPersonCompany = "NNPC Corp.",
                        ReviewMessage = "You are the best at what you do.",
                        CompanyLogoName = "nnpc.jpg"
                    }
                };
        }

        public void OnGet()
        {
        }

        public class JobExperience
        {
            public string CompanyName { get; set; }

            public string ElementId { get; set; }

            public List<string> Responsiblites { get; set; }

            public JobExperience()
            {
                Responsiblites = new List<string>();
            }
        }

        public class Review
        {
            public string ReviewedBy { get; set; }

            public string ReviewMessage { get; set; }
            public string CompanyLogoName { get; set; }

            public string ReviewedPersonCompany { get; set; }
        }
    }
}
