import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { EquipmentService } from '../../services/equipment.service';
import { Equipment } from '../../models/equipment.model';

@Component({
  selector: 'app-equipment-list',
  standalone: true,
  imports: [CommonModule], 
  templateUrl: './equipment-list.component.html',
   styleUrls: ['./equipment-list.component.css']
})
export class EquipmentListComponent implements OnInit {
  equipment: Equipment[] = [];
  loading = false;
  error: string | null = null;

  constructor(private service: EquipmentService) {}

  ngOnInit(): void {
    this.load();
  }

  load(): void {
    this.loading = true;
    this.error = null;

    this.service.getAll().subscribe({
      next: data => {
        this.equipment = data;
        this.loading = false;
      },
      error: () => {
        this.error = 'Failed to load equipment';
        this.loading = false;
      }
    });
  }
  
  edit(item: Equipment): void {
  const updated = {
    name: item.name.endsWith(' (edited)')
      ? item.name.replace(' (edited)', '')
      : item.name + ' (edited)',
    serialNumber: item.serialNumber,
    purchaseDate: item.purchaseDate,
    status: item.status,
    category: item.category,
    location: item.location
  };

  this.service.update(item.id, updated).subscribe({
    next: () => {
      this.load(); // 🔁 רענון רשימה
    },
    error: () => {
      this.error = 'Failed to update equipment';
    }
  });
}



  remove(id: number): void {
    if (!confirm('Are you sure?')) return;

    this.service.delete(id).subscribe(() => {
      this.equipment = this.equipment.filter(x => x.id !== id);
    });
  }

  add(): void {
  const newItem = {
    name: 'New Equipment',
    serialNumber: 'SN-' + Math.floor(Math.random() * 10000),
    purchaseDate: new Date().toISOString(),
    status: 0,
    category: 'General',
    location: 'HQ'
  };

  this.service.create(newItem).subscribe({
    next: () => {
      this.load();
    },
    error: () => {
      this.error = 'Failed to add equipment';
    }
  });
}

}
