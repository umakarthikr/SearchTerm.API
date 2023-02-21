import { Component, OnInit } from '@angular/core';
import { SearchApiService } from './Services/SearchApi.services';
import { User } from './Classes/User'
import {FormBuilder} from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent{
  title = 'SearchTermUI';

  constructor(private searchApiService: SearchApiService) { }

  lstUsers!: User[];

  searchUser(searchString : string) {
    this.searchApiService.getUsers(searchString)
      .subscribe
      (
        data => {
          this.lstUsers = data;
        }
    );

  }

}
