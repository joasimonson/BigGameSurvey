import { pagination } from "../../types/pagination";

export type RecordsResponse = {
    collection: RecordResponseItem[];
    pagination: pagination;
}

export interface RecordResponseItem extends Record {
    game: Game;
    genre: Genre;
}

export type Game = {
    id: number;
    title: string;
    platform: Platform;
}

export type Genre = {
    id: number;
    name: string;
}

export type Record = {
    id: number;
    name: string;
    age: number;
    insertedAt: string;
}

export type Platform = 'XBOX' | 'PC' | 'PLAYSTATION';