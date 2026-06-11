# Hire Me Page Redesign — Design Spec

**Date:** 2026-06-11
**Page:** `src/Web/Pages/Hire.cshtml` (`/hire/`)
**Status:** Approved design

## Goal

Reimagine the `/hire/` page from a raw, resume-dump document into a polished, on-brand
candidate landing page aimed at **recruiters and hiring managers**. The page recreates
Tobi Kareem's resume from real career data and offers a **single consolidated, downloadable
CV**. Skills are highlighted, **.NET / ASP.NET Core is featured prominently**, and the
**Private Pilot License** certification is included.

## Source of truth

Career data comes from `C:\Projects\FindJobs\career-ops\output\html\cv-*.html`. All tailored
variants share identical **work experience, education, certifications, and skills**; only the
**Professional Summary** and **Core Competencies** are tailored per company. The consolidated
page uses the canonical sections verbatim and a neutral, .NET-forward summary/competencies.

### Key content correction
The live site says "currently working at Tesla." The CV data shows the current role is
**Staff Software Engineer at Intuit (Sep 2024 – Present)**; Tesla was Nov 2018 – Aug 2023.
The redesigned page uses the **current** data. (Home/About pages still say Tesla — out of
scope here, noted for a later pass.)

## Page structure (top → bottom)

1. **Hero**
   - Headshot: `~/lib/images/tobiTesla.PNG`
   - Name: "Tobi Kareem"; title: "Staff Software Engineer"
   - Neutral, .NET-forward pitch (1–2 lines), e.g.:
     > Staff Software Engineer with 12+ years building and shipping full-stack products end
     > to end — **ASP.NET Core / .NET 8** and Go backends behind React + TypeScript front
     > ends. Proven at scale: 50K+ daily events on Kafka, multi-region Cosmos DB, 99.95%
     > uptime, and P0 MTTR cut from 45 to 12 minutes.
   - Location: Bay Area, CA
   - **Two equal CTAs:** `Download Résumé` (→ `/files/tobi-kareem-cv.pdf`) and `Contact me`
     (→ `/Contact`)
   - Social links: LinkedIn, GitHub

2. **Highlights strip** — stat cards from real numbers:
   `12+ yrs experience` · `99.95% uptime` · `50K+ daily events` · `P0 MTTR 45→12 min`

3. **Core competencies** — neutral superset, .NET first:
   .NET / ASP.NET Core · Full-Stack (React + TypeScript) · Distributed Systems ·
   Event-Driven (Kafka) · API & Identity Platforms (OAuth2/OIDC) · Cloud (Azure/AWS/GCP) ·
   Production Reliability / SLOs · LLM Integration

4. **Experience timeline** — vertical timeline, real history in order:
   Intuit → ICE → Tesla → Advantasure → Black Knight → Aviat Networks → Aptech.
   Each entry: company, role, period, location, accomplishment bullets (canonical text,
   `<strong>` highlights preserved). Collapses to single column on mobile.

5. **Skills** — replace the three mismatched "tier" SVG icons with the CV's real skill
   groups as labeled tag chips, **.NET group surfaced first**:
   Languages · Frontend/Full-Stack · Backend · AI/ML · Identity · Distributed Systems ·
   Data · Cloud & Infra · Practices.

6. **Education & Certifications** — compact two-column:
   - Education: M.Sc Hofstra University (May 2018); B.Sc (Hons) Babcock University (Jun 2014)
   - Certifications: Microsoft Exam 483: Programming in C# (2019); Employability Skills
     Certification — PSENSE (2014); **Private Pilot License** (called out explicitly).

7. **Contact CTA band** — closing CTA repeating `Download Résumé` + email/Contact so users
   don't scroll back up. Email: `captain@tobikareem.com`.

## Consolidated downloadable CV

- Produce **one consolidated CV** hosted at `src/Web/wwwroot/files/tobi-kareem-cv.pdf`.
- Build it from a new neutral HTML source (reuse the existing CV stylesheet from
  `career-ops/output/html`) with: neutral .NET-forward summary, superset competencies, and
  the canonical experience/education/certs/skills. The consolidated HTML is also saved back
  into `C:\Projects\FindJobs\career-ops\output` (per "consolidate all my resumes here").
- Render the consolidated HTML → PDF using headless Chromium (Playwright `page.pdf`). If
  automated rendering is unavailable, fall back to the career-ops PDF pipeline; do **not**
  ship a company-tailored PDF as the canonical download.

## Visual design

- **On-brand palette**, reusing existing `site.css` tokens instead of raw Bootstrap blue:
  - Background cream `#fefaf6`
  - Primary accent **teal `#2a9d8f`** (already used in `site.css`)
  - Secondary accent terracotta `#e07a5f`
  - Dark slate text
- **Preserve the existing site fonts.** Use the site's current font stack (as defined by
  `site.css` / Bootstrap defaults). Do **not** introduce new web fonts on the page — the
  redesign changes layout and structure only, keeping the same look, feel, color, and
  typography. (The downloadable CV PDF keeps its own separate typography; that is not the
  web page.)
- Type scale uses relative weight/size within the existing font family (distinct section
  headers vs body) — no font-family changes. Generous spacing, card surfaces with subtle
  borders/shadows, hover states on cards/buttons/timeline entries.
- Fully responsive: timeline and grids collapse to a single column at mobile widths.

## Technical architecture

- **`HireModel` (`Hire.cshtml.cs`)** holds the content as typed, immutable data so the view
  is loops over data, not hardcoded HTML:
  - `record Experience(string Company, string Role, string Period, string Location, string[] Bullets)`
  - `record SkillGroup(string Label, string Items)`
  - `record Highlight(string Value, string Label)`
  - `record Competency(string Name)` (or a `string[]`)
  - `record Credential(string Title, string Org, string Year)` for education + certs
  - Expose `IReadOnlyList<...>` properties populated in the model; `OnGet` stays trivial.
  - Bullet text may contain inline `<strong>`; render with `Html.Raw` on a controlled,
    in-repo constant set only (no user input) — acceptable since content is static.
- **`Hire.cshtml`** rewritten to render those collections inside a `.hire-page` wrapper.
- **New `src/Web/wwwroot/css/hire.css`**, every selector scoped under `.hire-page`, linked
  in `_Layout.cshtml` head alongside the existing `about.css` link (matching convention).
- **Assets:** create `src/Web/wwwroot/files/` and add `tobi-kareem-cv.pdf`. Remove/replace
  the three tier SVGs (`presentation.svg`, `business.svg`, `data.svg`) usage — superseded by
  the tag-chip skill layout; leave the files unless cleanup is requested.
- **`tenYearsAgo`/`timeSpan`** inline calc in the current view is replaced by a real
  `12+ years` highlight derived from a start-year constant (2014) on the model.

## Out of scope (noted, not fixed here)

- Home page `showSlides` carousel JS error (`site.js`).
- Global TinyMCE "invalid API key" load on every page (a small guard could be folded in
  later if desired).
- Updating Tesla → Intuit references on Home/About pages.

## Testing / verification

No test project exists in the solution. Verification is manual:
- `dotnet build Fortune.sln` succeeds.
- Run the app; load `/hire/` at desktop (1440) and mobile (390) widths via Playwright;
  confirm layout, on-brand colors, working `Download Résumé` (PDF downloads) and `Contact`
  CTAs, and that .NET + Private Pilot License are visibly featured.
- Confirm no new console errors introduced by the page.
