export class UserLDto {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    active: boolean;
    birthday: Date;
    roles: string[];
    permissionClaims: string[];

    hasPermission(claim) : boolean {
        var hasPermission = this.permissionClaims.indexOf(claim) >= 0;
        return hasPermission;
    }

    isInRole(role) : boolean {
        var isInRole = this.roles.indexOf(role) >= 0;
        return isInRole;
    }
}