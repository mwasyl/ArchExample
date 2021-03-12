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
  }

  onSave(): void {
    this.customerService.saveCustomer(this.selectedCustomer)
      .subscribe(() => 
      { 
        console.log('done'); 
        this.message = "Customer succesfully updated."; 
      });
  }

  getCustomers(): void {
    this.customerService.getCustomers()
        .subscribe(customers => this.customers = customers);
  }

  ngOnInit(): void {
    this.getCustomers();
  }

}
