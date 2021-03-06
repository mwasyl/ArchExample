import { Component, OnInit } from '@angular/core';
import { Customer } from '../customer';
import { CustomerService } from '../customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  customers: Customer[] = [];
  selectedCustomer?: Customer;
  message: string;

  constructor(private customerService: CustomerService) {}

  onSelect(customer: Customer): void {
    this.selectedCustomer = customer;
    this.message = null;
  }

  onCreateCustomer(): void {
    let customer: Customer = {
      id: null,
      firstName: "",
      surName: ""
    };
    this.selectedCustomer = customer;
  }

  onSave(): void {
    if (this.validate(this.selectedCustomer))
    {
      if (this.selectedCustomer.id === null)
      {
        this.customerService.createCustomer(this.selectedCustomer)
        .subscribe(() => 
        { 
          console.log('done'); 
          this.message = "Customer succesfully created."; 
          this.customers.push(this.selectedCustomer);
        });
      } else {
        this.customerService.saveCustomer(this.selectedCustomer)
        .subscribe(() => 
        { 
          console.log('done'); 
          this.message = "Customer succesfully updated."; 
        });
      }
    }
  }

  validate(customer: Customer): boolean {
    if(!customer.firstName || 0 === customer.firstName.length)
    {
      this.message = "Customer first name is required."; 
      return false;
    } else if (!customer.surName || 0 === customer.surName.length)  {
      this.message = "Customer surname is required."; 
      return false;
    } else {
      return true;
    }
  }

  getCustomers(): void {
    this.customerService.getCustomers()
        .subscribe(customers => this.customers = customers);
  }

  ngOnInit(): void {
    this.getCustomers();
  }

}
