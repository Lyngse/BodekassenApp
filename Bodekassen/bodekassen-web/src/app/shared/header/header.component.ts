import { Component, OnInit, HostListener } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  showBurgerMenu: boolean = false;
  constructor() { }

  ngOnInit() {
  }

  @HostListener('window:resize', ['$event'])
  onResize(event) {
    event.target.innerWidth;
    if(event.target.innerWidth < 768) {
      this.showBurgerMenu = true;
    } else {
      this.showBurgerMenu = false;
    }
  }

}
