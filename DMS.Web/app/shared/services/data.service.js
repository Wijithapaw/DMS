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
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var http_1 = require("@angular/http");
var app_config_service_1 = require("../../core/services/app-config.service");
var DataService = (function () {
    function DataService(http, appConfigService) {
        this.http = http;
        this.appConfigService = appConfigService;
    }
    DataService.prototype.getUrl = function (controler, action) {
        return this.pathCombine(this.appConfigService.apiUrl, this.pathCombine(controler, action));
    };
    DataService.prototype.pathCombine = function (part1, part2) {
        return part1 + (part2 != '' ? '/' + part2 : '');
    };
    DataService.prototype.get = function (controler, action, id) {
        if (action === void 0) { action = ''; }
        if (id === void 0) { id = 0; }
        var url = this.getUrl(controler, action);
        if (id > 0)
            url += '/' + id;
        return this.http.get(url);
    };
    DataService.prototype.put = function (controler, action, id, jsonData) {
        console.log(jsonData);
        var headers = new http_1.Headers({ 'Content-Type': 'application/json; charset=utf-8' });
        var options = new http_1.RequestOptions({ headers: headers });
        var url = this.getUrl(controler, action);
        url += '/' + id;
        return this.http.put(url, jsonData, options)
            .map(function (res) { return res.json(); });
    };
    DataService.prototype.handleError = function (error) {
        console.error(error);
    };
    return DataService;
}());
DataService = __decorate([
    core_1.Injectable(),
    __metadata("design:paramtypes", [http_1.Http, app_config_service_1.AppConfigService])
], DataService);
exports.DataService = DataService;
//# sourceMappingURL=data.service.js.map