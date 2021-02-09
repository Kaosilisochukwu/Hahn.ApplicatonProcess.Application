import { IRegister } from "applicants-service"
import {  inject } from 'aurelia-framework'
export class Register{

  firstName = ""
  familyName = ""
  email = ""
  age = 0
  address = ""
  country = ""
  hired = false

  addApplicant(): void{
    const applicantDetails:IRegister = {
      firstName: this.firstName,
      familyName: this.familyName,
      email: this.email,
      age: this.age,
      address: this.address,
      country: this.country,
      hired: false
    }
    console.log(applicantDetails)
  }
  styleObject = "position: absolute; top: 0; background-color: rgba(0, 0, 0, 0.639); color: white; height: 100vh; width: 100%; display: none; justify-content: center; align-items: center;"
}