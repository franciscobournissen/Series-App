import { Component } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-search-series',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './search-series.component.html'
})
export class SearchSeriesComponent {
  title: string = '';
  genre: string = '';
  results: any[] = [];
  isLoading: boolean = false;

  constructor(private http: HttpClient) {}

  search() {
    this.isLoading = true;
    const params = new HttpParams()
      .set('Title', this.title)
      .set('Genre', this.genre);

    this.http.get<any[]>('/api/series/search', { params }).subscribe({
      next: (data) => {
        this.results = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error('Error al buscar series:', err);
        this.isLoading = false;
      }
    });
  }
}
