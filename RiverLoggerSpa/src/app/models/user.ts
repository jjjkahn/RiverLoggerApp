export class User {
  name: string;
  lastName: string;
  password: string;
  email: string;

  constructor(
    _name: string,
    _lastName: string,
    _password: string,
    _email: string
  ) {
    this.name = _name;
    this.lastName = _lastName;
    this.email = _email;
    this.password = _password;
  }
}
