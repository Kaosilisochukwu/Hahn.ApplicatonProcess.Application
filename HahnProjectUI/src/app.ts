require('bootstrap/dist/css/bootstrap.min.css')
import * as $ from 'jquery'


import {RouterConfiguration, Router} from 'aurelia-router';
import { PLATFORM  } from 'aurelia-pal'

export class App {
  router: Router;
  message = "Hello World"
  configureRouter(config: RouterConfiguration, router: Router): void {
    this.router = router;
    config.map([
      { route: '', name: 'home',  moduleId: PLATFORM.moduleName('./applicants') , title: 'Applicants'},
      { route: 'register', name: 'register',  moduleId: PLATFORM.moduleName('./register') , title: 'Register'},
      { route: 'details', name: 'details',  moduleId: PLATFORM.moduleName('./details') , title: 'Details'},
      { route: 'edit/:id', name: 'edit', moduleId: PLATFORM.moduleName('./EditApplicant'), title: 'Edit' },
      { route: 'details/:id',     name: 'details', moduleId: PLATFORM.moduleName('./details'), title: 'details' }
    ]);
  }
}







