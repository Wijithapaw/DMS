import { Injectable } from '@angular/core';

import { UserDto } from '../../account/models/user-dto';

@Injectable()
export class UserSessionService {
    user: UserDto;
}