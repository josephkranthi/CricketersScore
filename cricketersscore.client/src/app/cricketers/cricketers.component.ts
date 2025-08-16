import { Component, OnInit } from '@angular/core';
//import { FormBuilder, FormGroup, Validators } from '@angular/forms'; // reactive form sample
import { CricketersService, Cricketer } from '../cricketers.service';

@Component({
  selector: 'app-cricketers',
  templateUrl: './cricketers.component.html',
  styleUrls: ['./cricketers.component.css']
})
export class CricketersComponent implements OnInit {

  title = 'Cricketers Score';

  public players: Cricketer[] = [];

  // For edit form
  editedItem: Cricketer | null = null;
  editedIndex: number = -1;
  showEditForm: boolean = false;

  // editForm!: FormGroup;     //R
  // showEditForm = false;
  //editedIndex: number = -1;

  // For add form
  newPlayer: Cricketer = { rank: 0, name: '', score: 0 };
  // playerForm!: FormGroup;  //R

  constructor(private cricketersService: CricketersService) { }
  //constructor(private cricketersService: CricketersService, private fb: FormBuilder) { } // R

  ngOnInit() {
    this.getPlayers();
    // Reactive Form Setup
    //this.playerForm = this.fb.group({
    //  rank: [0, Validators.required],
    //  name: ['', Validators.required],
    //  score: [0, Validators.required]
    //});

    //this.editForm = this.fb.group({
    //  rank: [{ value: 0, disabled: true }, Validators.required],
    //  name: ['', Validators.required],
    //  score: [0, Validators.required]
    //});
  }

  // ---- CRUD ----

  // READ
  getPlayers() {
    this.cricketersService.getPlayers().subscribe(
      (result) => {
        this.players = result;
      },
      (error) => {
        console.error('Error fetching cricketers:', error);
      }
    );
  }

  // CREATE
  addPlayer() {
    //  if (this.playerForm.invalid) return; R
    // const newPlayer = this.playerForm.value; R
    this.cricketersService.addPlayer(this.newPlayer).subscribe(
      (created) => {
        this.players.push(created);
        console.log('Player added:', created);

        // reset form
        this.newPlayer = { rank: 0, name: '', score: 0 };
      },
      (error) => console.error('Error adding player:', error)
    );
  }

  // UPDATE
  updateItem() {
    if (!this.editedItem) return;
    //    const updated = { ...this.editForm.getRawValue() }; R

    this.cricketersService.updatePlayer(this.editedItem.rank, this.editedItem).subscribe(
      () => {
        this.players[this.editedIndex] = { ...this.editedItem! };
        console.log('Cricketer updated successfully');
        this.resetForm();
      },
      (error) => {
        console.error('Error updating cricketer:', error);
      }
    );
  }

  // DELETE
  deletePlayer(rank: number, index: number) {
    this.cricketersService.deletePlayer(rank).subscribe(
      () => {
        this.players.splice(index, 1);
        console.log('Player deleted');
      },
      (error) => console.error('Error deleting player:', error)
    );
  }

  // ---- Helpers ----

  edit(index: number) {
    this.editedItem = { ...this.players[index] };
    this.editedIndex = index;
    this.showEditForm = true;
  }
  //edit(index: number) { // R
  //  this.editedIndex = index;
  //  const player = this.players[index];
  //  this.editForm.setValue({
  //    rank: player.rank,
  //    name: player.name,
  //    score: player.score
  //  });
  //  this.showEditForm = true;
  //}

  isRankFieldDisabled(): boolean {
    return true;
  }

  resetForm() {
    this.showEditForm = false;
    this.editedItem = null;
    this.editedIndex = -1;
  }
}
