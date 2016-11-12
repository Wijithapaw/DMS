import { InMemoryDbService } from 'angular-in-memory-web-api'

export class InMemoryDataService implements InMemoryDbService {
    createDb() {
        let donors = [
            { firstName: 'Wijitha', lastName: 'Wijenayake', email: 'wijitha@yopmail.com', birthday: new Date(1985, 8, 1) },
            { firstName: 'Widura', lastName: 'Wijenayake', email: 'widura@yopmail.com', birthday: new Date(1990, 8, 8) },
			{ firstName: 'Kasun', lastName: 'Jayasinghe', email: 'kasun@yopmail.com', birthday: new Date(1988, 5, 1) }
        ];

        let projects = [
            { title: 'Scholarship 1', description: 'A/L student', startDate: new Date(2012, 8, 1), endDate: new Date(2015, 8, 1) },
            { title: 'Scholarship 2', description: 'University student', startDate: new Date(2013, 8, 1), endDate: new Date(2015, 8, 1) },
            { title: 'Scholarship 3', description: 'O/L student', startDate: new Date(2014, 8, 1), endDate: new Date(2015, 8, 1) }
        ];
        return { donors, projects}
    }
}