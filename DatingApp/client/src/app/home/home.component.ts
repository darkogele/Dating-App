import { HttpClient } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { RegisterComponent } from "../register/register.component";

@Component({
  selector: 'app-home',
  standalone: true,
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  imports: [RegisterComponent]
})
export class HomeComponent implements OnInit {
  http = inject(HttpClient);

  registerMode = false;
  users: any;

  ngOnInit(): void {
    this.getUsers();
  }

  registerToggle() {
    this.registerMode = !this.registerMode;
  }

  getUsers() {
    this.http.get('https://localhost:5001/api/users').subscribe({
      next: (data) => this.users = data,
      error: (err) => console.error(err),
      complete: () => console.log('complete')
    })
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
}
