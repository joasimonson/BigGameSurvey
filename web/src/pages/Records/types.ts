import { Game, Genre, Record } from "../../types/model";
import { pagination } from "../../types/pagination";

export type RecordsResponse = {
    collection: RecordResponseItem[];
    pagination: pagination;
}

export interface RecordResponseItem extends Record {
    game: Game;
    genre: Genre;
}