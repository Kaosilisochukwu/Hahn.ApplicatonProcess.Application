import {autoinject} from 'aurelia-framework';
import {RouteConfig} from 'aurelia-router';
import {ApplicantService} from './applicants-service';

@autoinject
export class Details{
  
  constructor(private userService: ApplicantService) { }
  slug:number;
  // activate(params:any, routeConfig: RouteConfig): Promise<any>{
  //   return this.userService.getApplicant(params.id)
  //   .then(user => {
  //     routeConfig.navModel.setTitle(user.name);
  //   });
  //   this.slug = params.slug
  // }
}