"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
var core_1 = require('@angular/core');
var router_1 = require('@angular/router');
var project_1 = require('../models/project');
var project_service_1 = require('../services/project.service');
var EditProjectComponent = (function () {
    function EditProjectComponent(route, projectService) {
        this.route = route;
        this.projectService = projectService;
        this.subtitle = 'Edit Project';
    }
    EditProjectComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.route.params.forEach(function (params) {
            var id = +params['id'];
            _this.projectService.getProject(id).then(function (project) { return _this.project = (project != null ? project : new project_1.Project()); });
        });
    };
    EditProjectComponent.prototype.onSubmit = function () {
        this.projectService.updateProject(this.project)
            .then(function (response) { alert('Updated'); });
    };
    EditProjectComponent.prototype.cancel = function () {
        alert('cancel');
    };
    EditProjectComponent = __decorate([
        core_1.Component({
            moduleId: module.id,
            selector: 'edit-project',
            templateUrl: 'edit-project.component.html'
        }), 
        __metadata('design:paramtypes', [router_1.ActivatedRoute, project_service_1.ProjectService])
    ], EditProjectComponent);
    return EditProjectComponent;
}());
exports.EditProjectComponent = EditProjectComponent;
//# sourceMappingURL=edit-project.component.js.map