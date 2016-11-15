import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { AppModule } from './app.module';
const platform = platformBrowserDynamic();
platform.bootstrapModule(AppModule);

//import { platformBrowser } from '@angular/platform-browser';
//// The app module factory produced by the static offline compiler
//import { AppModuleNgFactory } from './app.module.ngfactory';
//const platform = platformBrowser();
//platform.bootstrapModule(AppModuleNgFactory);






