using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages
{
    public class HireModel : PageModel
    {
        // Career start year used to derive the "years of experience" highlight.
        private const int CareerStartYear = 2014;

        public int YearsExperience => DateTime.Now.Year - CareerStartYear;

        public string Role => "Staff Software Engineer";

        public string Location => "Bay Area, CA";

        public string Email => "captain@tobikareem.com";

        public string Pitch =>
            "Staff Software Engineer with 12+ years building and shipping full-stack products " +
            "end to end — ASP.NET Core / .NET 8 and Go backends behind React + TypeScript front " +
            "ends. Proven at scale: 50K+ daily events on Kafka, multi-region Cosmos DB, 99.95% " +
            "uptime, and P0 MTTR cut from 45 to 12 minutes. Deep in distributed systems, " +
            "OAuth2/OIDC identity platforms, and production LLM integration.";

        public IReadOnlyList<Highlight> Highlights { get; } = new[]
        {
            new Highlight("12+", "Years experience"),
            new Highlight("99.95%", "Uptime at scale"),
            new Highlight("50K+", "Daily events on Kafka"),
            new Highlight("45→12 min", "P0 MTTR reduction"),
        };

        public IReadOnlyList<string> Competencies { get; } = new[]
        {
            ".NET / ASP.NET Core",
            "Full-Stack (React + TypeScript)",
            "Distributed Systems",
            "Event-Driven (Kafka)",
            "API & Identity Platforms (OAuth2/OIDC)",
            "Cloud (Azure/AWS/GCP)",
            "Production Reliability / SLOs",
            "LLM Integration",
        };

        public IReadOnlyList<Experience> Experiences { get; } = new[]
        {
            new Experience("Intuit", "Staff Software Engineer — Partner Platform", "Sep 2024 – Present", "San Francisco Bay Area", new[]
            {
                "Designed and own the partner integration API layer processing <strong>8,000+ daily partner transactions</strong> at <strong>99.95% uptime</strong>",
                "Built partner-facing admin and analytics dashboards in <strong>React + TypeScript</strong> with a <strong>Node.js</strong> BFF layer over the .NET APIs",
                "Built core services on <strong>.NET 8</strong> and <strong>Go</strong> with circuit breakers, retry policies, and idempotency guarantees across all integration surfaces",
                "Integrated LLM capabilities (OpenAI API, Claude API) into partner workflows; built evaluation harnesses and observability pipelines to measure AI quality in production",
                "Implemented <strong>OAuth2/JWT</strong> authentication and authorization for all external partner APIs; extending to AI agent auth patterns",
                "Lead a team of 4 engineers; define technical standards, run architecture reviews, and own the incident response runbook",
            }),
            new Experience("ICE (Intercontinental Exchange)", "Staff Software Engineer — Mortgage Transaction Platform", "Aug 2023 – Sep 2024", "Bay Area", new[]
            {
                "Designed and maintained a multi-region <strong>Azure Cosmos DB</strong> layer serving <strong>15,000+ daily partner requests</strong> with strict ACID guarantees",
                "Architected cross-region replication with consistency-level tuning to meet both latency SLAs and correctness requirements",
                "Built <strong>React + TypeScript</strong> monitoring dashboards and internal tooling surfacing real-time anomaly detection and audit data to partner-operations teams",
                "Built the partner API surface (<strong>.NET</strong> and <strong>Java/Spring Boot</strong>) with OAuth2, rate limiting, and structured audit logging for regulatory compliance",
                "Led incident response and post-mortems; reduced P0 MTTR from <strong>45 min to 12 min</strong> through SLO design and runbook automation",
            }),
            new Experience("Tesla", "Senior / Staff Software Engineer — Manufacturing & Identity Platforms", "Nov 2018 – Aug 2023", "Fremont, CA", new[]
            {
                "Built <strong>Tesla WARP</strong>, the internal OAuth2 + Identity Server platform unifying access for <strong>3,000+ internal users</strong>, <strong>500+ external partners</strong>, and <strong>10+ applications</strong> (OIDC, SAML2, token lifecycle, RBAC)",
                "Built the WARP identity admin console and partner self-service portal in <strong>React + TypeScript</strong> on a <strong>Node.js</strong> API layer",
                "Led the event-driven <strong>MRP</strong> platform on Apache Kafka (<strong>.NET</strong> and <strong>Java/Spring Boot</strong>) processing <strong>50,000+ daily events</strong> across <strong>4 global facilities</strong>",
                "Delivered real-time inventory visibility through <strong>React + TypeScript</strong> operations dashboards across Fremont, Shanghai, Berlin, and Austin",
            }),
            new Experience("Advantasure (formerly Tessellate)", "Software Developer", "Sep 2018 – Nov 2018", "Glen Allen, VA", new[]
            {
                "Built and maintained healthcare information system components following <strong>SOLID</strong> design principles",
                "Championed <strong>Test-Driven Development</strong> across the team — mocking, unit testing, and integration testing with Postman collections (.NET, ASP.NET Web Forms, Angular)",
            }),
            new Experience("Black Knight", "Software Developer", "Jan 2017 – Aug 2017", "Jacksonville, FL", new[]
            {
                "Built a cross-platform mobile app for an Educational Loan Financial Management System using <strong>Xamarin.Forms</strong>, expanding accessibility for borrowers",
                "Maintained UAT/STG environments and deployment pipelines with <strong>Jenkins</strong>; partnered with business owners and SMEs (.NET Framework, ASP.NET MVC, WCF, REST, Angular, SQL)",
            }),
            new Experience("Aviat Networks", "Technical Support Engineer", "Jan 2015 – Dec 2015", "Lagos, Nigeria", new[]
            {
                "Delivered onsite and remote troubleshooting for enterprise communication links serving banks and 300+ clients; installed and configured telecom networks and completed Tellabs 7100 packet-optical transport training",
            }),
            new Experience("Aptech Computer Education", "Intern", "May 2013 – Sep 2013", "Oyo, Nigeria", new[]
            {
                "Built an Examination Expert System (final-year project) and website prototypes with HTML, CSS, and JavaScript (.NET Framework, Bootstrap)",
            }),
        };

        public IReadOnlyList<SkillGroup> SkillGroups { get; } = new[]
        {
            new SkillGroup(".NET / Backend", ".NET 8 / ASP.NET Core / MVC, Spring Boot, Node.js/Express, Go, WCF"),
            new SkillGroup("Languages", "C#/.NET 8/Core, TypeScript/JavaScript, Python, Go, Java, Swift, Objective-C"),
            new SkillGroup("Frontend / Full-Stack", "React, TypeScript, Node.js, Angular, HTML/CSS, REST & GraphQL APIs"),
            new SkillGroup("Identity", "OAuth2, OIDC, SAML2, Identity Server, JWT, RBAC"),
            new SkillGroup("Distributed Systems", "Apache Kafka, Azure Service Bus, circuit breakers, saga, event-driven"),
            new SkillGroup("Data", "Azure Cosmos DB (multi-region), PostgreSQL, SQL Server, Redis"),
            new SkillGroup("Cloud & Infra", "Azure, AWS, GCP, Kubernetes, Docker, Terraform, Helm"),
            new SkillGroup("AI / ML", "OpenAI API, Anthropic API, RAG pipelines, eval harnesses, agentic workflows"),
            new SkillGroup("Practices", "TDD, unit/integration testing, CI/CD (Jenkins), SOLID, OpenTelemetry, SLO/SLA design"),
        };

        public IReadOnlyList<Credential> Education { get; } = new[]
        {
            new Credential("M.Sc, Computer Science / Computer Engineering", "Hofstra University", "May 2018"),
            new Credential("B.Sc (Honors), Computer Science (Technology)", "Babcock University", "June 2014"),
        };

        public IReadOnlyList<Credential> Certifications { get; } = new[]
        {
            new Credential("Microsoft Exam 483: Programming in C#", "Microsoft", "2019"),
            new Credential("Employability Skills Certification", "PSENSE", "2014"),
            new Credential("Private Pilot License", "FAA", ""),
        };

        public void OnGet() { }
    }

    public record Experience(string Company, string Role, string Period, string Location, string[] Bullets);
    public record SkillGroup(string Label, string Items);
    public record Highlight(string Value, string Label);
    public record Credential(string Title, string Org, string Year);
}
