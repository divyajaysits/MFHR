export class Resp {
  success: boolean = false;;
  message: string = "";
  entity?: any;
}

export class Employee {
  iD: number = 0;
  isActive: boolean = true;
  titleId: number = 0;
  civilStatusId: number = 0;

  firstName: string = "";
  lastName: string = "";
  dateofbirth: Date = new Date();
  genderId: number = 0;
  nIC: string = "";
  nationality: string = "";
  email: string = "";
  mobilePhoneNo: string = "";
  addressLine1: string = "";
  addressLine2: string = "";
  city: string = "";
  country: string = "";

  ePFNo: string = "";
  designation: string = "";
  dateJoined: Date = new Date();
}
