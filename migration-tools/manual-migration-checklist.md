# Manual Content Migration Checklist
## orkinosai-org/website → orkinosai-org/orkinosai-web-new

This checklist ensures comprehensive migration of all custom content, branding, docs, and company info from the previous website repository.

### Prerequisites
- [ ] Access to source repository (orkinosai-org/website)
- [ ] Local clone of destination repository (orkinosai-org/orkinosai-web-new)
- [ ] Backup of current destination repository state

### Phase 1: Repository Analysis
- [ ] Review source repository structure and content
- [ ] Identify custom content vs. framework content
- [ ] Document source repository file tree
- [ ] Identify any custom code implementations
- [ ] Review commit history for recent changes
- [ ] Check for any environment-specific configurations

### Phase 2: Documentation Migration
- [ ] **README Files**
  - [ ] Copy source README.md to `docs/WEBSITE_README.md`
  - [ ] Merge relevant sections with existing README.md
  - [ ] Update company/project specific information
  
- [ ] **Documentation Folders**
  - [ ] Copy `docs/` folder to `docs/website/`
  - [ ] Copy any guide files (`guides/`, `help/`, etc.)
  - [ ] Update internal documentation links
  
- [ ] **Contributing Guidelines**
  - [ ] Copy CONTRIBUTING.md to `docs/WEBSITE_CONTRIBUTING.md`
  - [ ] Merge with existing contribution guidelines
  
- [ ] **Other Markdown Files**
  - [ ] Copy all `.md` files to `docs/website/`
  - [ ] Update cross-references and links

### Phase 3: Branding Assets Migration
- [ ] **Images and Logos**
  - [ ] Copy `assets/images/` to `Oqtane.Server/wwwroot/images/branding/`
  - [ ] Copy `images/` to `Oqtane.Server/wwwroot/images/content/`
  - [ ] Copy company logos to `Oqtane.Server/wwwroot/images/`
  - [ ] Copy favicon and icon files to `Oqtane.Server/wwwroot/`
  - [ ] Verify image formats and optimize if needed
  
- [ ] **Stylesheets and CSS**
  - [ ] Copy `assets/css/` to `Oqtane.Server/wwwroot/css/custom/`
  - [ ] Copy `styles/` to `Oqtane.Server/wwwroot/css/custom/`
  - [ ] Review CSS for framework compatibility
  - [ ] Update CSS references in themes
  
- [ ] **Fonts and Typography**
  - [ ] Copy custom fonts to `Oqtane.Server/wwwroot/fonts/`
  - [ ] Update font references in CSS files
  
- [ ] **Other Assets**
  - [ ] Copy JavaScript files to `Oqtane.Server/wwwroot/js/custom/`
  - [ ] Copy any media files (videos, audio) to appropriate locations

### Phase 4: Content Pages Migration
- [ ] **Razor Pages**
  - [ ] Copy `Pages/` to `Oqtane.Server/Pages/Custom/`
  - [ ] Update namespace references
  - [ ] Verify routing compatibility
  
- [ ] **Components**
  - [ ] Copy `Components/` to `Oqtane.Client/UI/Custom/`
  - [ ] Update component registrations
  - [ ] Verify Blazor component compatibility
  
- [ ] **Views and Templates**
  - [ ] Copy `Views/` to `Oqtane.Server/Views/Custom/`
  - [ ] Update view references in controllers
  
- [ ] **Company Information Pages**
  - [ ] About Us page content
  - [ ] Contact information
  - [ ] Team member information
  - [ ] Company history and mission

### Phase 5: Custom Themes Migration
- [ ] **Client-side Themes**
  - [ ] Copy `Themes/` to `Oqtane.Client/Themes/Custom/`
  - [ ] Update theme registration
  - [ ] Verify theme compatibility
  
- [ ] **Server-side Theme Assets**
  - [ ] Copy `wwwroot/Themes/` to `Oqtane.Server/wwwroot/Themes/Custom/`
  - [ ] Update theme CSS references
  - [ ] Test theme functionality

### Phase 6: Configuration Migration
- [ ] **Application Settings**
  - [ ] Review `appsettings.json` files
  - [ ] Copy custom settings to `config/website/`
  - [ ] Merge relevant settings with destination appsettings
  
- [ ] **Web Configuration**
  - [ ] Copy `web.config` if present
  - [ ] Review IIS-specific configurations
  
- [ ] **Package Configuration**
  - [ ] Copy `package.json` if present
  - [ ] Review Node.js dependencies
  - [ ] Update build scripts if needed

### Phase 7: Legal and Policy Documents
- [ ] **Legal Documents**
  - [ ] Copy `legal/` folder to `docs/legal/`
  - [ ] Privacy policy files
  - [ ] Terms of service
  - [ ] License files
  
- [ ] **Compliance Documents**
  - [ ] GDPR compliance documents
  - [ ] Cookie policy
  - [ ] Accessibility statements

### Phase 8: Custom Code and Features
- [ ] **Custom Modules**
  - [ ] Identify custom Oqtane modules
  - [ ] Copy module files to appropriate locations
  - [ ] Update module registrations
  
- [ ] **Custom Services**
  - [ ] Copy custom service implementations
  - [ ] Update dependency injection registrations
  
- [ ] **Database Migrations**
  - [ ] Identify custom database changes
  - [ ] Create migration scripts if needed
  
- [ ] **API Controllers**
  - [ ] Copy custom API controllers
  - [ ] Update routing and authentication

### Phase 9: Issues and Pull Requests Review
- [ ] **Open Issues Review**
  - [ ] Export list of open issues from source repository
  - [ ] Categorize issues (bug, enhancement, documentation)
  - [ ] Create corresponding issues in destination repository
  
- [ ] **Closed Issues Review**
  - [ ] Review recently closed issues for implemented features
  - [ ] Verify all implemented features are present in destination
  
- [ ] **Pull Requests Review**
  - [ ] Review merged pull requests for custom implementations
  - [ ] Verify all accepted contributions are migrated
  - [ ] Document any missing implementations

### Phase 10: Testing and Validation
- [ ] **Build Testing**
  - [ ] Verify solution builds successfully
  - [ ] Fix any compilation errors
  - [ ] Update package references if needed
  
- [ ] **Functionality Testing**
  - [ ] Test migrated themes
  - [ ] Test custom pages and components
  - [ ] Verify image and asset loading
  - [ ] Test responsive design
  
- [ ] **Content Validation**
  - [ ] Verify all content is accessible
  - [ ] Check for broken links
  - [ ] Validate form functionality
  - [ ] Test search functionality

### Phase 11: Reference Updates
- [ ] **Internal Links**
  - [ ] Update internal documentation links
  - [ ] Fix relative path references
  - [ ] Update image src attributes
  
- [ ] **External References**
  - [ ] Update repository URLs in documentation
  - [ ] Update deployment scripts
  - [ ] Update CI/CD configurations

### Phase 12: Documentation and Cleanup
- [ ] **Migration Documentation**
  - [ ] Document what was migrated
  - [ ] List any content that was left behind (with reasons)
  - [ ] Create post-migration setup instructions
  
- [ ] **Code Cleanup**
  - [ ] Remove temporary migration files
  - [ ] Clean up unused references
  - [ ] Update .gitignore if needed
  
- [ ] **Final Validation**
  - [ ] Complete end-to-end testing
  - [ ] Verify all acceptance criteria are met
  - [ ] Get stakeholder approval

### Migration Completion Checklist
- [ ] All custom content migrated successfully
- [ ] Directory structure properly organized
- [ ] No significant information lost
- [ ] Migration report generated and reviewed
- [ ] Post-migration testing completed
- [ ] Documentation updated
- [ ] Team notified of migration completion

---

**Migration Tools Available:**
- `migration-tools/content-migration.ps1` - PowerShell automated migration script
- `migration-tools/content-migration.sh` - Bash automated migration script
- `migration-tools/manual-migration-checklist.md` - This checklist

**Notes:**
- Always run migration scripts with `--dry-run` or `-WhatIf` first
- Keep backups of both source and destination repositories
- Test thoroughly in a development environment before production migration
- Document any custom modifications made during migration