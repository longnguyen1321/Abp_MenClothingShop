import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-import-cart',
  templateUrl: './import-cart.component.html',
  styleUrls: ['./import-cart.component.scss']
})
export class ImportCartComponent implements OnInit {

  constructor() { }

  @Input() testingChild = '';
  ngOnInit(): void {

  }

}
