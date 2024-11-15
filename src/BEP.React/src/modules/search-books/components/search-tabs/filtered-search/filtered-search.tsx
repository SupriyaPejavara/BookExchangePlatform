import React, { useEffect, useState } from "react";
import FormHelperText from "@material-ui/core/FormHelperText";
import FormControl from "@material-ui/core/FormControl";
import Select from "@material-ui/core/Select";

import {
  Button,
  Grid,
  InputLabel,
  MenuItem,
  TextField,
} from "@material-ui/core";
import { Autocomplete } from "@material-ui/lab";
import SearchIcon from "@material-ui/icons/Search";
import { Controller, useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";

import { AuthorsService, BookService, CategoryService } from "services";
import { Author, Category, Book } from "types";
import { VariantType, useSnackbar } from "notistack";

const schema = yup.object().shape({
  title: yup.string(),
  description: yup.string(),
  isbn: yup.string(),
  publisher: yup.string(),  
  filterOperator: yup.string(),
});

interface FilteredSearchProps {
  page: number;
  setTotalRecords: React.Dispatch<React.SetStateAction<number>>;
  rowsPerPage: number;
  setBooks: React.Dispatch<React.SetStateAction<Book.Book[] | undefined>>;
  isActiveSearch: any;
  setActiveSearch: any;
}

const FilteredSearch = ({
  page,
  rowsPerPage,
  setTotalRecords,
  setBooks,
  setActiveSearch,
  isActiveSearch,
}: FilteredSearchProps) => {
  const [authorsOptions, setAuthorsOptions] = useState<Author.Author[]>([]);
  const [categoriesOptions, setCategoriesOptions] = useState<
    Category.Category[]
  >([]);

  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<Book.SearchFilters>({
    resolver: yupResolver(schema),
  });

  const [searchFilters, setSearchFilters] = useState<Book.SearchFilters>();

  const onSubmit = async (data: Book.SearchFilters) => {
    setActiveSearch(false);
    setSearchFilters(data);
    try {
      data.pageSize = rowsPerPage;
      data.pageNumber = page;
      console.log(data);
      const result = await BookService.GetBooks(data);
      setTotalRecords(result.totalRecords);
      setBooks(result.data);
    } catch (e) {
      console.log(e);
    }
  };

  useEffect(() => {
    console.log("Inside use effect", isActiveSearch, searchFilters);
    const fetchData = async () => {
      try {
        const authors = await AuthorsService.GetAll();
        const categories = await CategoryService.GetAll();
        setAuthorsOptions(authors);
        setCategoriesOptions(categories);
      } catch (e) {
        console.log(e);
      }
    };

    fetchData();

     if (isActiveSearch || searchFilters) {
      onSubmit(searchFilters || {});
    }
  }, [isActiveSearch, page, rowsPerPage]);

  const sortByOptions = ["Title", "ISBN"];

  return (
    <form onSubmit={handleSubmit(onSubmit)}>
      <Grid container spacing={3}>
        <Grid item xs={12} sm={3}>
          <TextField
            {...register("title")}
            autoComplete="title"
            name="title"
            variant="outlined"
            label="Title"
            fullWidth
            error={!!errors.title}
            helperText={errors.title?.message}
          />
        </Grid>
        <Grid item xs={12} sm={3}>
          <TextField
            {...register("description")}
            autoComplete="description"
            name="description"
            variant="outlined"
            label="Description"
            fullWidth
            error={!!errors.description}
            helperText={errors.description?.message}
          />
        </Grid>
        <Grid item xs={12} sm={3}>
          <TextField
            {...register("isbn")}
            autoComplete="isbn"
            name="isbn"
            variant="outlined"
            label="ISBN"
            fullWidth
            error={!!errors.isbn}
            helperText={errors.isbn?.message}
          />
        </Grid>
        <Grid item xs={12} sm={3}>
          <TextField
            {...register("publisher")}
            autoComplete="publisher"
            name="publisher"
            variant="outlined"
            label="Publisher"
            fullWidth
            error={!!errors.publisher}
            helperText={errors.publisher?.message}
          />
        </Grid>
        <Grid item xs={12} sm={3}>
          <Controller
            name="authors"
            control={control}
            render={({ field: { onChange }, ...props }) => (
              <Autocomplete
                multiple
                {...props}
                id="book-category"
                options={authorsOptions}
                getOptionLabel={(option: Author.Author) => option.name}
                renderOption={(option) => option.name}
                onChange={(e, data) => onChange(data)}
                filterSelectedOptions
                renderInput={(params) => (
                  <TextField {...params} variant="outlined" label="Author" />
                )}
              />
            )}
          />
        </Grid>
        <Grid item xs={12} sm={3}>
          <Controller
            name="categories"
            control={control}
            render={({ field: { onChange }, ...props }) => (
              <Autocomplete
                multiple
                {...props}
                id="book-author"
                options={categoriesOptions}
                getOptionLabel={(option: Category.Category) => option.label}
                renderOption={(option) => option.label}
                onChange={(e, data) => onChange(data)}
                filterSelectedOptions
                renderInput={(params) => (
                  <TextField {...params} variant="outlined" label="Category" />
                )}
              />
            )}
          />
        </Grid>        
        <Grid item xs={12} sm={2}>
          <Controller
            name="sortBy"
            control={control}
            render={({ field: { onChange }, ...props }) => (
              <Autocomplete
                {...props}
                id="sort-by"
                options={sortByOptions}
                onChange={(e, data) => onChange(data)}
                filterSelectedOptions
                renderInput={(params) => (
                  <TextField {...params} variant="outlined" label="Sort By" />
                )}
              />
            )}
          />         
        </Grid>
        <Grid item xs={12} sm={4}>
          <Button
            variant="contained"
            color="primary"
            endIcon={<SearchIcon />}
            type="submit"
          >
            Search
          </Button>
        </Grid>
      </Grid>
    </form>
  );
};
export { FilteredSearch };
