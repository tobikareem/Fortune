# Hire Me Page Redesign Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Rebuild `/hire/` as a polished, on-brand candidate landing page driven by typed data, recreating Tobi Kareem's resume from real career data with a single consolidated, downloadable CV.

**Architecture:** Move all page content into typed records on `HireModel`; rewrite `Hire.cshtml` to render those collections inside a `.hire-page` wrapper; add a scoped `hire.css` (linked in `_Layout` like the existing `about.css`) that reuses the site's existing palette and fonts (no new fonts). Generate one consolidated CV PDF via the existing `career-ops/generate-pdf.mjs` Playwright pipeline and host it at `wwwroot/files/`.

**Tech Stack:** ASP.NET Core Razor Pages (.NET 9), Bootstrap 5, plain CSS, Playwright (existing career-ops PDF generator).

**Verification note:** The solution has **no test project** and CLAUDE.md forbids inventing a `dotnet test` workflow. Verification per task is therefore `dotnet build Fortune.sln` (must succeed) plus, in the final task, visual checks via Playwright at desktop/mobile widths. Commit after each task.

---

### Task 1: Replace HireModel with typed content data

**Files:**
- Modify (full rewrite): `src/Web/Pages/Hire.cshtml.cs`

- [ ] **Step 1: Rewrite the page model with typed records and real data**

Replace the entire contents of `src/Web/Pages/Hire.cshtml.cs` with:

```csharp
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
```

- [ ] **Step 2: Build to verify the model compiles**

Run: `dotnet build Fortune.sln`
Expected: Build succeeded, 0 errors. (The view still references old markup but does not reference removed members, so it compiles.)

- [ ] **Step 3: Commit**

```bash
git add src/Web/Pages/Hire.cshtml.cs
git commit -m "feat(hire): typed content model for Hire Me page"
```

---

### Task 2: Rewrite Hire.cshtml to render the model

**Files:**
- Modify (full rewrite): `src/Web/Pages/Hire.cshtml`

- [ ] **Step 1: Replace the view markup**

Replace the entire contents of `src/Web/Pages/Hire.cshtml` with:

```cshtml
@page
@using Web.Pages.Classes
@model Web.Pages.HireModel
@{
    ViewData["Title"] = "Hire Me";
    ViewData["ActivePage"] = BreadCrumbs.Hire;
}

<div class="hire-page">

    <section class="hire-hero">
        <div class="hire-hero__photo">
            <img src="~/lib/images/tobiTesla.PNG" alt="Tobi Kareem" asp-append-version="true" />
        </div>
        <div class="hire-hero__body">
            <h1 class="hire-hero__name">Tobi Kareem</h1>
            <p class="hire-hero__role">@Model.Role</p>
            <p class="hire-hero__location">@Model.Location</p>
            <p class="hire-hero__pitch">@Model.Pitch</p>
            <div class="hire-hero__cta">
                <a class="hire-btn hire-btn--primary" href="/files/tobi-kareem-cv.pdf" download>
                    <i class="fas fa-download"></i> Download Résumé
                </a>
                <a class="hire-btn hire-btn--secondary" asp-page="/Contact">
                    <i class="fas fa-envelope"></i> Contact me
                </a>
            </div>
            <ul class="hire-social">
                <li><a href="https://www.linkedin.com/in/oluwatobikareem/" target="_blank" rel="noopener" aria-label="LinkedIn"><i class="fab fa-linkedin"></i></a></li>
                <li><a href="https://github.com/tobikareem" target="_blank" rel="noopener" aria-label="GitHub"><i class="fab fa-github"></i></a></li>
            </ul>
        </div>
    </section>

    <section class="hire-highlights">
        @foreach (var h in Model.Highlights)
        {
            <div class="hire-stat">
                <span class="hire-stat__value">@h.Value</span>
                <span class="hire-stat__label">@h.Label</span>
            </div>
        }
    </section>

    <section class="hire-section">
        <h2 class="hire-section__title">Core competencies</h2>
        <ul class="hire-tags">
            @foreach (var c in Model.Competencies)
            {
                <li class="hire-tag">@c</li>
            }
        </ul>
    </section>

    <section class="hire-section">
        <h2 class="hire-section__title">Experience</h2>
        <div class="hire-timeline">
            @foreach (var e in Model.Experiences)
            {
                <article class="hire-job">
                    <div class="hire-job__head">
                        <span class="hire-job__company">@e.Company</span>
                        <span class="hire-job__period">@e.Period</span>
                    </div>
                    <div class="hire-job__role">@e.Role</div>
                    <div class="hire-job__location">@e.Location</div>
                    <ul class="hire-job__bullets">
                        @foreach (var b in e.Bullets)
                        {
                            <li>@Html.Raw(b)</li>
                        }
                    </ul>
                </article>
            }
        </div>
    </section>

    <section class="hire-section">
        <h2 class="hire-section__title">Skills</h2>
        <div class="hire-skills">
            @foreach (var g in Model.SkillGroups)
            {
                <div class="hire-skill">
                    <span class="hire-skill__label">@g.Label</span>
                    <span class="hire-skill__items">@g.Items</span>
                </div>
            }
        </div>
    </section>

    <section class="hire-section hire-credentials">
        <div class="hire-credentials__col">
            <h2 class="hire-section__title">Education</h2>
            @foreach (var ed in Model.Education)
            {
                <div class="hire-cred">
                    <div class="hire-cred__title">@ed.Title</div>
                    <div class="hire-cred__meta"><span class="hire-cred__org">@ed.Org</span> · <span>@ed.Year</span></div>
                </div>
            }
        </div>
        <div class="hire-credentials__col">
            <h2 class="hire-section__title">Certifications</h2>
            @foreach (var ce in Model.Certifications)
            {
                <div class="hire-cred">
                    <div class="hire-cred__title">@ce.Title</div>
                    <div class="hire-cred__meta">
                        @if (!string.IsNullOrWhiteSpace(ce.Org)) { <span class="hire-cred__org">@ce.Org</span> }
                        @if (!string.IsNullOrWhiteSpace(ce.Org) && !string.IsNullOrWhiteSpace(ce.Year)) { <text> · </text> }
                        @if (!string.IsNullOrWhiteSpace(ce.Year)) { <span>@ce.Year</span> }
                    </div>
                </div>
            }
        </div>
    </section>

    <section class="hire-cta-band">
        <h2>Let's build something together.</h2>
        <p>Open to senior / staff engineering roles. Grab the résumé or get in touch.</p>
        <div class="hire-hero__cta">
            <a class="hire-btn hire-btn--primary" href="/files/tobi-kareem-cv.pdf" download>
                <i class="fas fa-download"></i> Download Résumé
            </a>
            <a class="hire-btn hire-btn--secondary" href="mailto:@Model.Email">
                <i class="fas fa-envelope"></i> @Model.Email
            </a>
        </div>
    </section>

</div>
```

- [ ] **Step 2: Build to verify the view compiles**

Run: `dotnet build Fortune.sln`
Expected: Build succeeded, 0 errors.

- [ ] **Step 3: Commit**

```bash
git add src/Web/Pages/Hire.cshtml
git commit -m "feat(hire): render Hire Me page from typed model"
```

---

### Task 3: Add scoped hire.css and link it in the layout

**Files:**
- Create: `src/Web/wwwroot/css/hire.css`
- Modify: `src/Web/Pages/Shared/_Layout.cshtml` (add stylesheet link after the existing `about.css` link, ~line 24)

- [ ] **Step 1: Create `src/Web/wwwroot/css/hire.css`**

All selectors are scoped under `.hire-page`. No `font-family` is set anywhere — the page inherits the site's existing fonts. Colors reuse the existing site palette (cream `#fefaf6`, teal `#2a9d8f`, terracotta `#e07a5f`).

```css
/* Hire Me page — scoped under .hire-page. Inherits site fonts; uses site palette. */
.hire-page {
    --hire-teal: #2a9d8f;
    --hire-teal-dark: #1f7d72;
    --hire-terracotta: #e07a5f;
    --hire-cream: #fefaf6;
    --hire-ink: #2b2b2b;
    --hire-muted: #6b6b6b;
    --hire-border: #e7e1d9;
    --hire-radius: 12px;

    max-width: 1040px;
    margin: 0 auto;
    padding: 0 1rem 3rem;
    color: var(--hire-ink);
}

/* === HERO === */
.hire-page .hire-hero {
    display: flex;
    gap: 2rem;
    align-items: center;
    padding: 2.5rem 0 2rem;
}
.hire-page .hire-hero__photo img {
    width: 200px;
    height: 200px;
    object-fit: cover;
    border-radius: 50%;
    border: 4px solid #fff;
    box-shadow: 0 8px 24px rgba(0, 0, 0, 0.12);
}
.hire-page .hire-hero__body { flex: 1; min-width: 0; }
.hire-page .hire-hero__name { font-size: 2.4rem; font-weight: 700; margin: 0 0 .25rem; }
.hire-page .hire-hero__role { font-size: 1.2rem; color: var(--hire-teal-dark); font-weight: 600; margin: 0 0 .25rem; }
.hire-page .hire-hero__location { color: var(--hire-muted); margin: 0 0 1rem; }
.hire-page .hire-hero__pitch { font-size: 1.02rem; line-height: 1.7; margin: 0 0 1.5rem; max-width: 60ch; }

.hire-page .hire-hero__cta { display: flex; flex-wrap: wrap; gap: .75rem; margin-bottom: 1rem; }
.hire-page .hire-btn {
    display: inline-flex;
    align-items: center;
    gap: .5rem;
    padding: .7rem 1.4rem;
    border-radius: 999px;
    font-weight: 600;
    text-decoration: none;
    transition: transform .12s ease, box-shadow .12s ease, background-color .12s ease;
}
.hire-page .hire-btn--primary { background: var(--hire-teal); color: #fff; }
.hire-page .hire-btn--primary:hover { background: var(--hire-teal-dark); transform: translateY(-2px); box-shadow: 0 6px 16px rgba(42, 157, 143, .35); }
.hire-page .hire-btn--secondary { background: transparent; color: var(--hire-teal-dark); border: 2px solid var(--hire-teal); }
.hire-page .hire-btn--secondary:hover { background: rgba(42, 157, 143, .08); transform: translateY(-2px); }

.hire-page .hire-social { list-style: none; display: flex; gap: 1rem; padding: 0; margin: 0; }
.hire-page .hire-social a { color: var(--hire-muted); font-size: 1.4rem; transition: color .12s ease; }
.hire-page .hire-social a:hover { color: var(--hire-teal); }

/* === HIGHLIGHTS === */
.hire-page .hire-highlights {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    gap: 1rem;
    margin: 1rem 0 2.5rem;
}
.hire-page .hire-stat {
    background: #fff;
    border: 1px solid var(--hire-border);
    border-radius: var(--hire-radius);
    padding: 1.25rem 1rem;
    text-align: center;
}
.hire-page .hire-stat__value { display: block; font-size: 1.7rem; font-weight: 700; color: var(--hire-teal-dark); }
.hire-page .hire-stat__label { display: block; font-size: .85rem; color: var(--hire-muted); margin-top: .25rem; }

/* === SECTIONS === */
.hire-page .hire-section { margin-bottom: 2.5rem; }
.hire-page .hire-section__title {
    font-size: 1.3rem;
    font-weight: 700;
    margin: 0 0 1.2rem;
    padding-bottom: .5rem;
    border-bottom: 2px solid var(--hire-border);
}
.hire-page .hire-section__title::before {
    content: "";
    display: inline-block;
    width: 10px; height: 10px;
    margin-right: .6rem;
    border-radius: 2px;
    background: var(--hire-terracotta);
    vertical-align: middle;
}

/* === COMPETENCY TAGS === */
.hire-page .hire-tags { list-style: none; display: flex; flex-wrap: wrap; gap: .6rem; padding: 0; margin: 0; }
.hire-page .hire-tag {
    background: rgba(42, 157, 143, .10);
    color: var(--hire-teal-dark);
    border: 1px solid rgba(42, 157, 143, .25);
    border-radius: 6px;
    padding: .4rem .85rem;
    font-size: .92rem;
    font-weight: 500;
}

/* === TIMELINE === */
.hire-page .hire-timeline { position: relative; padding-left: 1.5rem; }
.hire-page .hire-timeline::before {
    content: "";
    position: absolute;
    left: 4px; top: 6px; bottom: 6px;
    width: 2px;
    background: var(--hire-border);
}
.hire-page .hire-job { position: relative; margin-bottom: 1.75rem; }
.hire-page .hire-job::before {
    content: "";
    position: absolute;
    left: -1.5rem; top: .45rem;
    width: 10px; height: 10px;
    border-radius: 50%;
    background: var(--hire-teal);
    box-shadow: 0 0 0 3px var(--hire-cream);
}
.hire-page .hire-job__head { display: flex; justify-content: space-between; align-items: baseline; gap: 1rem; flex-wrap: wrap; }
.hire-page .hire-job__company { font-size: 1.1rem; font-weight: 700; color: var(--hire-ink); }
.hire-page .hire-job__period { font-size: .85rem; color: var(--hire-muted); white-space: nowrap; }
.hire-page .hire-job__role { font-weight: 600; color: var(--hire-teal-dark); margin-top: .15rem; }
.hire-page .hire-job__location { font-size: .85rem; color: var(--hire-muted); margin-bottom: .5rem; }
.hire-page .hire-job__bullets { margin: 0; padding-left: 1.1rem; }
.hire-page .hire-job__bullets li { line-height: 1.6; margin-bottom: .35rem; }

/* === SKILLS === */
.hire-page .hire-skills { display: grid; grid-template-columns: repeat(2, 1fr); gap: 1rem; }
.hire-page .hire-skill {
    background: #fff;
    border: 1px solid var(--hire-border);
    border-radius: var(--hire-radius);
    padding: 1rem 1.1rem;
}
.hire-page .hire-skill__label { display: block; font-weight: 700; color: var(--hire-teal-dark); margin-bottom: .3rem; }
.hire-page .hire-skill__items { color: var(--hire-ink); font-size: .92rem; line-height: 1.5; }

/* === CREDENTIALS === */
.hire-page .hire-credentials { display: grid; grid-template-columns: repeat(2, 1fr); gap: 2rem; }
.hire-page .hire-cred { margin-bottom: .9rem; }
.hire-page .hire-cred__title { font-weight: 600; }
.hire-page .hire-cred__meta { font-size: .88rem; color: var(--hire-muted); }
.hire-page .hire-cred__org { color: var(--hire-teal-dark); }

/* === CTA BAND === */
.hire-page .hire-cta-band {
    text-align: center;
    background: rgba(42, 157, 143, .07);
    border: 1px solid var(--hire-border);
    border-radius: var(--hire-radius);
    padding: 2.25rem 1.5rem;
}
.hire-page .hire-cta-band h2 { font-weight: 700; margin: 0 0 .5rem; }
.hire-page .hire-cta-band p { color: var(--hire-muted); margin: 0 0 1.25rem; }
.hire-page .hire-cta-band .hire-hero__cta { justify-content: center; }

/* === RESPONSIVE === */
@media (max-width: 768px) {
    .hire-page .hire-hero { flex-direction: column; text-align: center; }
    .hire-page .hire-hero__cta, .hire-page .hire-social { justify-content: center; }
    .hire-page .hire-hero__pitch { margin-left: auto; margin-right: auto; }
    .hire-page .hire-highlights { grid-template-columns: repeat(2, 1fr); }
    .hire-page .hire-skills { grid-template-columns: 1fr; }
    .hire-page .hire-credentials { grid-template-columns: 1fr; gap: 1.5rem; }
}
```

- [ ] **Step 2: Link the stylesheet in `_Layout.cshtml`**

In `src/Web/Pages/Shared/_Layout.cshtml`, find this line (~line 24):

```html
    <link rel="stylesheet" href="~/css/about.css" asp-append-version="true" />
```

Add immediately after it:

```html
    <link rel="stylesheet" href="~/css/hire.css" asp-append-version="true" />
```

- [ ] **Step 3: Build to verify nothing broke**

Run: `dotnet build Fortune.sln`
Expected: Build succeeded, 0 errors.

- [ ] **Step 4: Commit**

```bash
git add src/Web/wwwroot/css/hire.css src/Web/Pages/Shared/_Layout.cshtml
git commit -m "feat(hire): scoped hire.css styling, on-brand palette"
```

---

### Task 4: Build the consolidated CV and host the downloadable PDF

**Files:**
- Create: `C:\Projects\FindJobs\career-ops\output\html\cv-tobi-kareem.html` (consolidated, neutral)
- Create: `src/Web/wwwroot/files/tobi-kareem-cv.pdf` (generated output)

- [ ] **Step 1: Create the consolidated HTML from an existing variant**

Copy the existing variant to the new consolidated filename (preserves the shared `<style>` and font references so fonts resolve):

```bash
cp "C:/Projects/FindJobs/career-ops/output/html/cv-tobi-kareem-anthropic-fullstack.html" \
   "C:/Projects/FindJobs/career-ops/output/html/cv-tobi-kareem.html"
```

- [ ] **Step 2: Neutralize the Professional Summary**

In `cv-tobi-kareem.html`, find the `summary-text` div content (the Anthropic-tailored sentence beginning "Staff Software Engineer with 8+ years…") and replace the inner text with:

```html
Staff Software Engineer with 12+ years building and shipping full-stack products end to end — ASP.NET Core / .NET 8 and Go backends behind React + TypeScript front ends. Proven at scale: 50K+ daily events on Kafka, multi-region Cosmos DB, 99.95% uptime, and P0 MTTR cut from 45 to 12 minutes. Deep in distributed systems, OAuth2/OIDC identity platforms, and production LLM integration.
```

- [ ] **Step 3: Neutralize the Core Competencies**

In `cv-tobi-kareem.html`, replace the entire `competencies-grid` block with this .NET-first, neutral set:

```html
    <div class="competencies-grid">
      <span class="competency-tag">.NET / ASP.NET Core</span>
      <span class="competency-tag">Full-Stack (React + TypeScript)</span>
      <span class="competency-tag">Distributed Systems</span>
      <span class="competency-tag">Event-Driven (Kafka)</span>
      <span class="competency-tag">API & Identity Platforms</span>
      <span class="competency-tag">Cloud (Azure / AWS / GCP)</span>
      <span class="competency-tag">Production Reliability / SLOs</span>
      <span class="competency-tag">LLM Integration</span>
    </div>
```

(Work experience, education, certifications — including the Private Pilot License — and skills are already canonical in this file; leave them unchanged.)

- [ ] **Step 4: Create the output folder and generate the PDF**

```bash
mkdir -p "C:/Users/toboi/OneDrive/Documents/Fortune/src/Web/wwwroot/files"
cd "C:/Projects/FindJobs/career-ops" && node generate-pdf.mjs \
  "output/html/cv-tobi-kareem.html" \
  "C:/Users/toboi/OneDrive/Documents/Fortune/src/Web/wwwroot/files/tobi-kareem-cv.pdf" \
  --format=letter
```

Expected: `✅ PDF generated: …/tobi-kareem-cv.pdf` with a non-zero size (~120 KB). If `playwright` is not installed in career-ops, run `npm --prefix "C:/Projects/FindJobs/career-ops" install` first, then re-run.

- [ ] **Step 5: Verify static-file serving is enabled**

Run: `rg -n "UseStaticFiles" src/Web`
Expected: at least one match (Razor Pages template enables it). If absent, add `app.UseStaticFiles();` in `src/Web/Extensions/DependentAppBuilder.cs` before routing — but it is expected to already exist.

- [ ] **Step 6: Commit**

```bash
git add src/Web/wwwroot/files/tobi-kareem-cv.pdf
git commit -m "feat(hire): host consolidated downloadable CV PDF"
```

(The consolidated HTML lives in the career-ops repo, not Fortune; commit it there separately if that repo tracks generated CVs.)

---

### Task 5: Visual verification at desktop and mobile

**Files:** none (verification only)

- [ ] **Step 1: Run the app**

Run: `dotnet run --project src/Web/Web.csproj`
Expected: app listening on `https://localhost:7213`.

- [ ] **Step 2: Verify desktop layout (1440×900)**

Using Playwright: resize to 1440×900, navigate to `https://localhost:7213/hire/`, take a full-page screenshot. Confirm:
- Hero shows the round `tobiTesla.PNG` photo, name, "Staff Software Engineer", pitch, and two equal CTA buttons (teal "Download Résumé", outlined "Contact me").
- Highlights strip shows 4 stat cards.
- Experience renders as a vertical timeline (Intuit first, Aptech last) with bold highlights inside bullets.
- Skills render as 9 labeled groups (".NET / Backend" first); Core competencies show ".NET / ASP.NET Core" first.
- Education + Certifications show side by side; **Private Pilot License is visible**.
- Colors match the site (cream background, teal/terracotta accents) — no raw Bootstrap-blue links.

- [ ] **Step 3: Verify the résumé download works**

Click "Download Résumé" (or navigate to `https://localhost:7213/files/tobi-kareem-cv.pdf`).
Expected: the consolidated PDF loads/downloads (HTTP 200, not 404).

- [ ] **Step 4: Verify mobile layout (390×844)**

Resize to 390×844, reload `/hire/`, take a full-page screenshot. Confirm hero stacks vertically and centers, highlights become 2 columns, skills/credentials collapse to a single column, and nothing overflows horizontally.

- [ ] **Step 5: Check console for new errors**

Confirm no new console errors are introduced by the page (the pre-existing global TinyMCE "invalid API key" warning is out of scope and may still appear).

- [ ] **Step 6: Final commit (if any screenshots/notes are saved)**

```bash
git add -A
git commit -m "chore(hire): verification screenshots"
```

(Skip if there is nothing to commit.)

---

## Self-Review

**Spec coverage:** Hero + photo (T2), CTAs (T2), highlights (T1/T2), core competencies .NET-first (T1/T2), experience timeline with current Intuit role (T1/T2), skills .NET-first as chips (T1/T2), education + certs incl. Private Pilot License (T1/T2), contact CTA band (T2), on-brand palette + preserved fonts (T3), consolidated downloadable CV (T4), responsive (T3/T5), verification (T5). All spec sections mapped.

**Placeholder scan:** No TBD/TODO; all code blocks are complete; the only "fall back" is a concrete `npm install` recovery step.

**Type consistency:** `Experience(Company, Role, Period, Location, Bullets)`, `SkillGroup(Label, Items)`, `Highlight(Value, Label)`, `Credential(Title, Org, Year)` — defined in Task 1 and used with the same property names in Task 2. CSS class names in Task 2 markup all have matching rules in Task 3.
