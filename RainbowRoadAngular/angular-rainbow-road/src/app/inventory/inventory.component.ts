import { Component, OnInit } from '@angular/core';
import { brick } from '../brick';

@Component({
  selector: 'app-inventory',
  templateUrl: './inventory.component.html',
  styleUrls: ['./inventory.component.css']
})
export class InventoryComponent implements OnInit {

  inventorytitle = 'Bricks';

  brick: brick = {
    id: 1,
    name: 'RedBrick'
  };

  constructor() { }

  ngOnInit(): void {
  }

}
