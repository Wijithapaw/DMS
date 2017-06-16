"use strict";
var router_1 = require('@angular/router');
var projects_component_1 = require('./projects.component');
var edit_project_component_1 = require('./edit-project/edit-project.component');
var projectsRoutes = [
    {
        path: 'projects',
        component: projects_component_1.ProjectsComponent
    },
    {
        path: 'project/new',
        component: edit_project_component_1.EditProjectComponent
    },
    {
        path: 'project/edit/:id',
        component: edit_project_component_1.EditProjectComponent
    }
];
exports.projectsRouting = router_1.RouterModule.forChild(projectsRoutes);
//# sourceMappingURL=projects.routing.js.map