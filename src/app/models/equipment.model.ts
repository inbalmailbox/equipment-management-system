export interface Equipment {
  id: number;
  name: string;
  serialNumber: string;
  purchaseDate: string;
  status: number;
  category: string;
  location: string;
}

export interface CreateEquipment {
  name: string;
  serialNumber: string;
  purchaseDate: string;
  status: number;
  category: string;
  location: string;
}
